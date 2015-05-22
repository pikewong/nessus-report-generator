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
	class DocxFromDotxTemplateOutputer : OutputFromTemplateFormater {

		public override void output (string path, string template, ref ReportGenerator.Record.Record record, ref Dictionary<String, String> dict) {
			if (!File.Exists(template)) {
				Console.Error.WriteLine("The Template doesn't exist.");
				Environment.Exit(0);
			}

			#region // before
			/*String tempPath = Environment.CurrentDirectory + "\\temp" + path;
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

			//using (DocX document = DocX.Load(@"median.dotx")){
			//    //document.ReplaceText("title", "askdjfhad", false, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			//    //document.Save();
			//}

			File.Delete(tempPath);*/
			#endregion
		}

		/*#region // DOTX to DOCX functions
		// Write the content of a stream into another.
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
		#endregion*/
	}
}
