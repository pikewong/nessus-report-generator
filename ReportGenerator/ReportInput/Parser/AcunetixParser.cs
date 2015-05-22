using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportGenerator.ReportInput.InputParser;
using ReportGenerator.Record;

namespace ReportGenerator.ReportInput.InputParser
{
    class AcunetixParser : TextFileParser
    {
        List <AffectedItem> tempAffectedItemList = null;
        AffectedItem tempAffectedItem = null;

        //int hardCodeLineCount = 0; // To search if there is next affected item, if =3, stop find and find next plugin name 
        //bool startHardCodeLineCount = false;

        // better to use state machine enum
        bool startReadEntry = false;
        bool startReadDescription = false;
        bool startReadImpact = false;
        bool startReadRecommendation = false;
        bool finishReadRecommendation = false;
        bool startReadAffectedItem = false;
        bool startFindAffectedItemDetail = false;
        bool startReadAffectedItemDetail = false;
        bool finishReadPluginName = false;
        bool startFindAffectedItemRequest = false;
        bool startReadAffectedItemRequest = false;
        bool startFindAffectedItemResponse = false;
        bool startReadAffectedItemResponse = false;
        bool startFindEndTag = false;

        //bool finishReadPluginName = false;
        //string pluginNameKey = "<td/><td/><td/><td colspan=\"12\" rowspan=\"2\" class=\"s32\">";
        //string pluginNameKeyType2 = "rowspan=\"2\" class=\"s32\">";
        //    //"<td colspan=\"12\" rowspan=\"2\" class=\"s32\">"
        //// <td/><td/><td/><td colspan="10" rowspan="2" class="s32">
        //string recommendationKey = "<td colspan=\"15\" class=\"s37\">Recommendation</td>";
        //string recommendationContentKey = "<td colspan=\"15\" class=\"s10\">";
        //string severityKey = "<td colspan=\"6\" class=\"s34\">Severity</td><td colspan=\"9\" class=\"s33\">";
        //string descriptionKey = "<td colspan=\"15\" class=\"s9\">Description</td>";
        //string descriptionContentKey = "<td colspan=\"15\" class=\"s10\">";
        //string impactKey = "<td colspan=\"15\" class=\"s9\">Impact</td>";
        //string impactContentKey = "<td colspan=\"15\" class=\"s10\">";
        //string affectedItemKey = "<td colspan=\"15\" class=\"s9\">Affected items</td>";
        //string affectedItemContentKey = "<td colspan=\"15\" class=\"s39\">";
        //string affectedItemDetailKey = "<td colspan=\"15\" class=\"s38\">";
        //string affectedItemDetailContentKey = "<td colspan=\"15\" class=\"s10\">"; 

        //string affectedItemRequestKey = "<td colspan=\"15\" class=\"s38\">Request</td>";
        //string affectedItemRequestContentKey ="<td colspan=\"15\" class=\"s40\">";
        //string affectedItemResponseKey = "<td colspan=\"15\" class=\"s38\">Response</td>";
        //string affectedItemResponseContentKey = "<td colspan=\"15\" class=\"s40\">";

        string pluginNameKey = "class=\"s32\">";

        //"<td colspan=\"12\" rowspan=\"2\" class=\"s32\">"
        // <td/><td/><td/><td colspan="10" rowspan="2" class="s32">
        string recommendationKey = "class=\"s37\">Recommendation</td>";
        string recommendationContentKey = "class=\"s10\">";
        string severityKey = "class=\"s34\">Severity</td>";
        string severityContentKey = "class=\"s33\">";
        string descriptionKey = "class=\"s9\">Description</td>";
        string descriptionContentKey = "class=\"s10\">";
        string impactKey = "class=\"s9\">Impact</td>";
        string impactContentKey = "lass=\"s10\">";
        string affectedItemKey = "class=\"s9\">Affected items</td>";
        string affectedItemContentKey = "class=\"s39\">";
        string affectedItemDetailKey = "class=\"s38\">";
        string affectedItemDetailContentKey = "class=\"s10\">";

        string affectedItemRequestKey = "class=\"s38\">Request</td>";
        string affectedItemRequestContentKey = "class=\"s40\">";
        string affectedItemResponseKey = "class=\"s38\">Response</td>";
        string affectedItemResponseContentKey = "class=\"s40\">";

        /// <summary>
        /// This is the processData method.
        /// It is used to process each line on the text file.
        /// </summary>
        /// <param name="content"></param>
        protected override void processData(string content)
        {

            if (!String.IsNullOrEmpty(content))
            {
                //if (startHardCodeLineCount)
                //    hardCodeLineCount++;
                // in here, only content start with "Host" and contains "is up"
                // would trigger the action to get the host list
                if (content.Contains("Scan of http://"))
                {

                    int e = content.IndexOf("Scan of http://");
                    int start = e + 15;
                    int end = content.IndexOf(":80/", start);
                    if (start < content.Length && end < content.Length)
                    {
                        tempIpList = content.Substring(start, end - start);
                        while (tempIpList.Length > 0 && tempIpList[tempIpList.Length - 1] == ' ')
                        {
                            tempIpList = tempIpList.Substring(0, tempIpList.Length - 1);
                        }

                    }
                }
                else if (content.Contains("Alert details"))
                    startReadEntry = true;
                else if (startReadEntry == true && !finishReadPluginName && content.Contains(pluginNameKey))
                {
                    int start = content.IndexOf(pluginNameKey) + pluginNameKey.Length;
                    int end = content.IndexOf("</td>", start);
                    tempPluginName = content.Substring(start, end - start);
                    finishReadPluginName = true;
                }
                //else if (startReadEntry == true && !finishReadPluginName && content.Contains(pluginNameKeyType2))
                //{
                //    int start = pluginNameKeyType2.Length;
                //    int end = content.IndexOf("</td>", start);
                //    tempPluginName = content.Substring(start, end - start);
                //    finishReadPluginName = true;
                //}
                else if (startReadEntry == true && content.Contains(severityKey))
                {
                    int start = content.IndexOf(severityContentKey) + severityContentKey.Length;
                    int end = content.IndexOf("</td>", start);
                    string temp = content.Substring(start, end - start);
                    tempRiskFactor = RiskFactorFunction.getEnum(temp);    // get risk factor
                }
                else if (startReadEntry == true && content.Contains(descriptionKey))
                    startReadDescription = true;
                else if (startReadEntry == true && startReadDescription == true && content.Contains(descriptionContentKey))
                {
                    int start = content.IndexOf(descriptionContentKey) + descriptionContentKey.Length;
                    int end = content.IndexOf("</td>", start);
                    tempDescription = content.Substring(start, end - start);
                }
                else if (startReadEntry == true && content.Contains(impactKey))
                {
                    startReadDescription = false;
                    startReadImpact = true;
                }
                else if (startReadEntry == true && startReadImpact == true && content.Contains(impactContentKey))
                {
                    int start = content.IndexOf(impactContentKey) + impactContentKey.Length;
                    int end = content.IndexOf("</td>", start);
                    tempImpact = content.Substring(start, end - start);

                }
                else if (startReadEntry == true && content.Contains(recommendationKey))
                {
                    startReadImpact = false;
                    startReadRecommendation = true;
                }
                else if (startReadEntry == true && startReadRecommendation == true && finishReadRecommendation == false && content.Contains(recommendationContentKey))
                {
                    int start = content.IndexOf(recommendationContentKey) + recommendationContentKey.Length;
                    int end = content.IndexOf("</td>", start);
                    tempRecommendation = content.Substring(start, end - start);
                }
                else if (startReadEntry == true && content.Contains(affectedItemKey))
                {
                    startReadRecommendation = false;
                    finishReadRecommendation = true;
                    tempAffectedItemList = new List<AffectedItem>();
                    startReadAffectedItem = true;
                }
                else if (startReadEntry == true && startReadAffectedItem == true && content.Contains(affectedItemContentKey))
                {
                    int start = content.IndexOf(affectedItemContentKey) + affectedItemContentKey.Length;
                    int end = content.IndexOf("</td>", start);
                    String tempName = content.Substring(start, end - start);
                    tempAffectedItem = new AffectedItem(tempName);
                    tempAffectedItemList.Add(tempAffectedItem);
                    startFindAffectedItemDetail = true;

                    //hardCodeLineCount = 0;
                    //startHardCodeLineCount = false;
                }
                else if (startReadEntry == true && startFindAffectedItemDetail == true && content.Contains(affectedItemDetailKey))
                {
                    //startReadAffectedItem = false;
                    startFindAffectedItemDetail = false;
                    startReadAffectedItemDetail = true;
                }
                else if (startReadEntry == true && startReadAffectedItemDetail == true && content.Contains(affectedItemDetailContentKey))
                {
                    int start = content.IndexOf(affectedItemDetailContentKey) + affectedItemDetailContentKey.Length;
                    int end = content.IndexOf("</td>", start);
                    String tempDetail = content.Substring(start, end - start);
                    tempAffectedItem.addDetail(tempDetail);

                    startFindAffectedItemRequest = true;
                    startFindEndTag = true;
                    //startHardCodeLineCount = true;
                }
                else if (startReadEntry == true && startFindAffectedItemRequest == true && content.Contains(affectedItemRequestKey))
                {
                    startReadAffectedItemDetail = false;
                    startFindAffectedItemRequest = false;
                    startReadAffectedItemRequest = true;
                }
                else if (startReadEntry == true && startReadAffectedItemRequest == true && content.Contains(affectedItemRequestContentKey))
                {
                    int start = content.IndexOf(affectedItemRequestContentKey) + affectedItemRequestContentKey.Length;
                    int end = content.IndexOf("</td>", start);
                    String tempRequest = content.Substring(start, end - start);
                    tempAffectedItem.addRequest(tempRequest);

                    startFindAffectedItemResponse = true;
                }
                else if (startReadEntry == true && startFindAffectedItemResponse == true && content.Contains(affectedItemResponseKey))
                {
                    startReadAffectedItemRequest = false;
                    startFindAffectedItemResponse = false;
                    startReadAffectedItemResponse = true;
                }
                else if (startReadEntry == true && startReadAffectedItemResponse == true && content.Contains(affectedItemResponseContentKey))
                {
                    int start = content.IndexOf(affectedItemRequestContentKey) + affectedItemRequestContentKey.Length;
                    int end = content.IndexOf("</td>", start);
                    String tempResponse = content.Substring(start, end - start);
                    tempAffectedItem.addResponse(tempResponse);

                }
                else if (startReadEntry == true && startFindEndTag == true && (content.Contains("<tr style=\"height:5px\">") || content.Contains("</body></html>") || content.Contains("<tr style=\"height:13px\">")))
                {

                    AcunetixDataEntry entry = new AcunetixDataEntry(tempPluginName,
                                                            tempIpList,
                                                            tempDescription,
                                                            tempImpact,
                                                            tempRiskFactor,
                                                            tempRecommendation,
                                                            tempFileName,
                                                            tempAffectedItemList,
                                                            "",
                                                            "",
                                                            "",
                                                            "",
                                                            "",
                                                            "",
                                                            "",
                                                            null);
                    this.tempRecord.acunetixAddEntry(entry);

                    tempPluginName = "";
                    tempDescription = "";
                    tempImpact = "";
                    tempRiskFactor = RiskFactor.NULL;
                    tempRecommendation = "";
                    tempAffectedItem = null;
                    tempAffectedItemList = null;

                    //hardCodeLineCount = 0;
                    //startHardCodeLineCount = false;

                    startReadDescription = false;
                    startReadImpact = false;
                    startReadRecommendation = false;
                    finishReadRecommendation = false;
                    startReadAffectedItem = false;
                    startFindAffectedItemDetail = false;
                    startReadAffectedItemDetail = false;
                    finishReadPluginName = false;

                    startFindAffectedItemRequest = false;
                    startReadAffectedItemRequest = false;
                    startFindAffectedItemResponse = false;
                    startReadAffectedItemResponse = false;

                    startFindEndTag = false;
                }

            }
        }
    }

}
