using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportGenerator.ReportInput.InputParser;
using ReportGenerator.Record;


namespace ReportGenerator.ReportInput.Parser
{
    class AcunetixXMLParser : XmlParser 
    {

        List<AffectedItem> tempAffectedItemList;
        AffectedItem tempAffectedItem;

        String tempModuleName;
        String tempIsFalsePositive;
        String tempAOP_SourceFile;
        String tempAOP_SourceLine;
        String tempAOP_Additional;
        String tempDetailedInformation;
        String tempType;
        List<AcunetixReference> tempAcunetixReferenceList;
        AcunetixReference tempAcunetixReference;

        override protected void startTag(string tag, Dictionary<string, string> attributes) {
            if (tag.CompareTo("StartURL") == 0)
            {
                elementStack.Push(tag);
            }
            else if (tag.CompareTo("ReportItem") == 0)
            {
                tempPluginName = "";
                tempRecommendation = "";
                tempDescription = "";
                tempImpact = "";
                tempRiskFactor = RiskFactor.NULL;
                tempAffectedItemList = new List<AffectedItem>();
                tempAffectedItem = new AffectedItem();

                tempModuleName ="";
                tempIsFalsePositive = "";
                tempAOP_SourceFile = "";
                tempAOP_SourceLine = "";
                tempAOP_Additional = "";
                tempDetailedInformation = "";
                tempType = "";
                tempAcunetixReferenceList = null;
                tempAcunetixReference = null;
                elementStack.Push(tag);
            }
            else if (elementStack.Count != 0)
            {
                if (tag.CompareTo("Name") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("Details") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("Affects") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("Severity") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("Impact") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("Description") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("Recommendation") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("Request") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("Response") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("ModuleName") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("IsFalsePositive") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("AOP_SourceFile") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("AOP_SourceLine") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("AOP_Additional") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("Type") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("DetailedInformation") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("References") == 0 && elementStack.Peek().CompareTo("ReportItem") == 0)
                {
                    tempAcunetixReferenceList = new List<AcunetixReference>();
                    elementStack.Push(tag);
                }
                else if (tag.CompareTo("Reference") == 0 && elementStack.Peek().CompareTo("References") == 0)
                {
                    tempAcunetixReference = new AcunetixReference();
                    elementStack.Push(tag);
                }
                else if (tag.CompareTo("Database") == 0 && elementStack.Peek().CompareTo("Reference") == 0)
                    elementStack.Push(tag);
                else if (tag.CompareTo("URL") == 0 && elementStack.Peek().CompareTo("Reference") == 0)
                    elementStack.Push(tag);
            }
        }

        override protected void pushContent(string content)
        {
            if (elementStack.Count != 0)
            {
                if (elementStack.Peek().CompareTo("StartURL") == 0)
                {
                    if (content.Contains("http://"))
                        content = content.Substring(content.IndexOf("http://") + "http://".Length);
                    if (content.Contains(":80/"))
                        content = content.Substring(0, content.IndexOf(":80/"));
                    tempIpList = content;
                }
                else if (elementStack.Peek().CompareTo("Name") == 0)
                {
                    tempPluginName = content;
                }
                else if (elementStack.Peek().CompareTo("Details") == 0)
                {
                    if (tempAffectedItem!=null)
                        tempAffectedItem.addDetail(content);
                }
                else if (elementStack.Peek().CompareTo("Affects") == 0)
                {
                    if (tempAffectedItem != null)
                        tempAffectedItem.setNameANDSubDirectory(content);
                }
                else if (elementStack.Peek().CompareTo("Severity") == 0)
                {
                    tempRiskFactor = RiskFactorFunction.getEnum(content);
                }
                else if (elementStack.Peek().CompareTo("Impact") == 0)
                {
                    tempImpact = content;
                }
                else if (elementStack.Peek().CompareTo("Description") == 0)
                {
                    tempDescription = content;
                }
                else if (elementStack.Peek().CompareTo("Recommendation") == 0)
                {
                    tempRecommendation = content;
                }
                else if (elementStack.Peek().CompareTo("Request") == 0)
                {
                    if (tempAffectedItem!= null)
                        tempAffectedItem.addRequest(content);
                }
                else if (elementStack.Peek().CompareTo("Response") == 0)
                {
                    if (tempAffectedItem!=  null)
                        tempAffectedItem.addResponse(content);
                }
                else if (elementStack.Peek().CompareTo("ModuleName") == 0)
                {
                    tempModuleName = content;
                }
                else if (elementStack.Peek().CompareTo("IsFalsePositive") == 0)
                {
                    tempIsFalsePositive = content;
                }
                else if (elementStack.Peek().CompareTo("AOP_SourceFile") == 0)
                {
                    tempAOP_SourceFile = content;
                }
                else if (elementStack.Peek().CompareTo("AOP_SourceLine") == 0)
                {
                    tempAOP_SourceLine = content;
                }
                else if (elementStack.Peek().CompareTo("AOP_Additional") == 0)
                {
                    tempAOP_Additional = content;
                }
                else if (elementStack.Peek().CompareTo("Type") == 0)
                {
                    tempType = content;
                }
                else if (elementStack.Peek().CompareTo("DetailedInformation") == 0)
                {
                    tempDetailedInformation = content;
                }
                else if (elementStack.Peek().CompareTo("Database") == 0)
                {
                    if (tempAcunetixReference!= null)
                        tempAcunetixReference.setDatabases(content);
                }
                else if (elementStack.Peek().CompareTo("URL") == 0)
                {
                    if (tempAcunetixReference != null)
                        tempAcunetixReference.setUrl(content);
                }
            }
        }

        override protected void endTag(string tag) {
            if (elementStack.Count != 0)
            {
                if (tag.CompareTo("ReportItem") == 0 &&
                    elementStack.Peek().CompareTo("ReportItem") == 0)
                {
                    elementStack.Pop();
                    tempAffectedItemList.Add(tempAffectedItem);
                    AcunetixDataEntry entry = new AcunetixDataEntry(tempPluginName,
                                              tempIpList,
                                              tempDescription,
                                              tempImpact,
                                              tempRiskFactor,
                                              tempRecommendation,
                                              tempFileName,
                                              tempAffectedItemList,
                                              tempModuleName,
                                              tempIsFalsePositive,
                                              tempAOP_SourceFile,
                                              tempAOP_SourceLine,
                                              tempAOP_Additional,
                                              tempDetailedInformation,
                                              tempType,
                                              tempAcunetixReferenceList);
                    tempRecord.acunetixAddEntry(entry);
                }
                else if (tag.CompareTo("Reference") == 0 &&
                    elementStack.Peek().CompareTo("Reference") == 0)
                {
                    elementStack.Pop();
                    tempAcunetixReferenceList.Add(tempAcunetixReference);
                }

                else if (elementStack.Peek().CompareTo(tag) == 0)
                {
                    elementStack.Pop();
                }
            }
        }
    }
}
