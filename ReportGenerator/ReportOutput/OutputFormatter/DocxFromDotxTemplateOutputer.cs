using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Xml;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ReportGenerator.ReportOutput.OutputFormatter {

	/// <summary>
	/// This is the DocxFromDotxTemplateOutputer Class.
	/// It is used to generate the report output from dotx template and output docx report.
	/// 
	/// This class is not been used within the Report Generator.
	/// </summary>
	class DocxFromDotxTemplateOutputer : OutputFromTemplateFormater {

		/// <summary>
		/// This is the abstract output method.
		/// It is used to output the file from given path and also given Record,
		/// with reference to the given template path and also a dictionary includes
		/// the string to be replaced.
		/// </summary>
		/// <param name="path">the file path for output</param>
		/// <param name="template">the template path for output</param>
		/// <param name="record">the Record for output</param>
		/// <param name="dict">the dict for string replacement</param>
		public override void output (string path, string template, ref ReportGenerator.Record.Record record, ref Dictionary<String, String> dict) {
			if (!File.Exists(template)) {
				Console.Error.WriteLine("The Template doesn't exist.");
				Environment.Exit(0);
			}

			#region // before
			String tempPath = Environment.CurrentDirectory + "\\temp" + path;
			String temptemp = "temp" + path;
			
			#region // DOTX to DOCX
			// Get dotx from the template path
			MemoryStream documentStream;
			String templatePath = Path.Combine(Environment.CurrentDirectory, template);
			using (Stream tplStream = File.OpenRead(templatePath)) {
				documentStream = new MemoryStream((int)tplStream.Length);
				CopyStream(tplStream, documentStream);
				documentStream.Position = 0L;
			}

			// Create the docx and save it without any changes to the template
			using (WordprocessingDocument wordTem = WordprocessingDocument.Open(documentStream, true)) {
				wordTem.ChangeDocumentType(DocumentFormat.OpenXml.WordprocessingDocumentType.Document);
				MainDocumentPart mainPart = wordTem.MainDocumentPart;
				mainPart.DocumentSettingsPart.AddExternalRelationship(
				   "http://schemas.openxmlformats.org/officeDocument/2006/relationships/attachedTemplate",
				   new Uri(templatePath, UriKind.Absolute));

				mainPart.Document.Save();
			}
			File.WriteAllBytes(tempPath, documentStream.ToArray());

			#endregion

			#region // Modified the docx, output the record
			path = Environment.CurrentDirectory + "\\" + path;
			File.Copy(tempPath, path, true);

			using (WordprocessingDocument doc = WordprocessingDocument.Open(path, true)) {
				// modify the body of the docx
				OpenXmlLeafTextElement[] textElement = doc.MainDocumentPart.Document.Descendants<OpenXmlLeafTextElement>().ToArray<OpenXmlLeafTextElement>();
				foreach (OpenXmlLeafTextElement txt in textElement) {
					switch (txt.Text) {
						case "[Type the document title]":
							txt.Text = "eWalker";
							break;
						case "[Type the document subtitle]":
						case "[Type the subtitle]":
							txt.Text = "eWalker subtitle";
							break;
						case "[Pick the date]":
							txt.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
							break;
						default:
							break;
					}
				}

				// modify the header of the docx
				foreach (HeaderPart header in doc.MainDocumentPart.HeaderParts) {
					string headerText = null;
					using (StreamReader sr = new StreamReader(header.GetStream())) {
						headerText = sr.ReadToEnd();
					}
					headerText = headerText.Replace("[Type the document title]", "eWalker");
					using (StreamWriter sw = new StreamWriter(header.GetStream(FileMode.Create))) {
						sw.Write(headerText);
					}
				}
				doc.MainDocumentPart.Document.Save();
			}
			//File.Delete(tempPath);
			#endregion

			File.Delete(tempPath);
			#endregion
		}

		/// <summary>
		/// This is the CopyStream method.
		/// It is used to write the content of a stream into another.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="target"></param>
		private static void CopyStream (Stream source, Stream target) {
			if (source != null) {
				MemoryStream mstream = source as MemoryStream;
				if (mstream != null)
					mstream.WriteTo(target);
				else {
					byte[] buffer = new byte[2048];
					int length = buffer.Length, size;
					while ((size = source.Read(buffer, 0, length)) != 0)
						target.Write(buffer, 0, size);
				}
			}
		}
	}
}
