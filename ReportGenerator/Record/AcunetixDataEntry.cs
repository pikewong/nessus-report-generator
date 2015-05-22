using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator.Record
{
    class AcunetixDataEntry : DataEntry
    {
        List<AffectedItem> affectedItemList;
        String subDomain;

        String moduleName ="";
        String isFalsePositive = "";
        String AOP_SourceFile = "";
        String AOP_SourceLine = "";
        String AOP_Additional = "";
        String detailedInformation = "";
        String acunetixType = "";
        List<AcunetixReference> acunetixReferenceList =null;
        String acunetixReferenceString = null; // for output excel

        //private String subDomain;

		/// <summary>
        /// This is the constructor of AcunetixDataEntry.
		/// </summary>
        public AcunetixDataEntry(String pluginName,
                               String ip,
                               String description,
                               String impact,
                               RiskFactor riskFactor,
                               String recommendation,
                               String fileName,
                               List<AffectedItem> affectedItemList,
                               String moduleName,
                               String isFalsePositive,
                               String AOP_SourceFile,
                               String AOP_SourceLine,
                               String AOP_Additional,
                               String detailedInformation,
                               String acunetixType,
                               List<AcunetixReference> acunetixReferenceList,
                               bool isGUI = false)
        {
			this.pluginName = pluginName;
			ipList.Add(ip);
			this.description = description == null ? "" : description;
			this.impact = impact == null ? "" : impact;
			this.riskFactor = riskFactor;
			this.recommendation = recommendation == null ? "" : recommendation;
			this.cveList = null;
			this.bidList = null;
			this.osvdbList = null;
			this.referenceLink = "";
			this.valid = true;
            this.type = EntryType.Acunetix;
            this.fileName = fileName;
            this.affectedItemList = affectedItemList;

            this.moduleName = moduleName;
            this.isFalsePositive = isFalsePositive;
            this.AOP_Additional = AOP_Additional;
            this.AOP_SourceFile = AOP_SourceFile;
            this.AOP_SourceLine = AOP_SourceLine;
            this.detailedInformation = detailedInformation;
            this.acunetixType = acunetixType;
            this.acunetixReferenceList = acunetixReferenceList;
            this.acunetixReferenceString = null;

            subDomain = "";

            if (!isGUI)
            {
                //hard code for polyu
                if (!ip.Contains("www.polyu.edu.hk"))
                {
                    if (ip.Contains("www.") && ip.Contains(".polyu.edu.hk"))
                    {
                        subDomain = ip.Substring(ip.IndexOf("www.") + 4, ip.IndexOf(".polyu.edu.hk") - 4);
                        foreach (AffectedItem item in affectedItemList)
                            item.setDepartment(subDomain);
                    }
                    else if (ip.Contains(".polyu.edu.hk"))
                    {
                        subDomain = ip.Substring(0, ip.IndexOf(".polyu.edu.hk"));
                        foreach (AffectedItem item in affectedItemList)
                            item.setDepartment(subDomain);
                    }
                }

                foreach (AffectedItem item in affectedItemList)
                    item.setLinkFromIp(ip);
            }
        }

        public String getModuleName(){return moduleName;}
        public String getIsFalsePositive(){return isFalsePositive;}
        public String getAOP_Additional(){return AOP_Additional;}
        public String getAOP_SourceFile(){return AOP_SourceFile;}
        public String getAOP_SourceLine(){return AOP_SourceLine;}
        public String getDetailedInformation(){return detailedInformation;}
        public String getAcunetixType(){return acunetixType;}
        public List<AcunetixReference> getAcunetixReferenceList(){return acunetixReferenceList;}
        public String getAcunetixReferenceListString()
        {
            if (acunetixReferenceString != null)
                return acunetixReferenceString;

            String temp = "";
            foreach (AcunetixReference reference in acunetixReferenceList)
                temp += reference.getDatabase() + " " + reference.getUrl() + ", ";
            if (!String.IsNullOrEmpty(temp))
				temp = temp.Substring(0, temp.Length - 2);
            return temp;
        }

        public void setAcunetixReferenceString(String acunetixReferenceString)
        {
            this.acunetixReferenceString = acunetixReferenceString;
        }

        public List<AffectedItem> getAffectedItemList() { return affectedItemList; }
        public String getSubDomain() { return subDomain;}
        public void setsubDomain(String subDomain) { this.subDomain = subDomain; }
    }

    public class AcunetixReference
    {
        private String database;
        private String url;

        public AcunetixReference()
        {
        }

        public AcunetixReference(String database, String url)
        {
            this.database = database;
            this.url = url;
        }

        public void setDatabases(String database){
            this.database = database;
        }

        public void setUrl(String url)
        {
            this.url = url;
        }

        public String getDatabase() { return database; }
        public String getUrl() { return url; }
    }

    public class AffectedItem
    {
        private String name;
        private String detail;
        private String request;
        private String response;
        private String subDirectory; 
        private String department;
        private String link;

        public AffectedItem() {
            this.name = "";
            this.detail = "";
            this.request = "";
            this.response = "";
            this.subDirectory = "";
            this.department = "";
            this.link = "";
        }

        public AffectedItem(String name)
        {
            setNameANDSubDirectory(name);
            this.detail = "";
            this.request = "";
            this.response = "";
            this.link = "";
        }

       // public void setDetail(String detail){this.detail = detail == null ? "" : detail;}

        public void setNameANDSubDirectory(String name)
        {
            this.name = name == null ? "" : name;
            if (name.StartsWith("/") && name.Length > 1)
            {
                int i = name.Substring(1, name.Length - 1).IndexOf('/');
                if (i != -1)
                    subDirectory = name.Substring(1, i);
                else
                    subDirectory = name.Substring(1, name.Length - 1);
            }
            else
                subDirectory = name;
            department = subDirectory;
        }

        public void setName(String name)
        {
            this.name = name == null ? "" : name;
        }

        public void addDetail(String detail)
        {
            if (this.detail == null)
                this.detail = detail;
            else
                this.detail += detail == null ? "" : detail;
        }

        public void addRequest(String request) {
            if (this.request == null)
                this.request = request;
            else
                this.request += request == null ? "" : request;
        }
        public void addResponse(String response) {
            if (this.response == null)
                this.response = response;
            else
                this.response += response == null ? "" : response;
        }
        public String getDetail() { return detail; }
        public String getName() { return name; }
        public String getRequest() { return request; }
        public String getResponse() { return response; }
        public String getSubDirectory() { return subDirectory;}
        public void setSubDirectory(String subDirectory) { this.subDirectory = subDirectory; }
        public void setDepartment(String department) { this.department = department; }
        public String getDepartment() { return department; }

        public void setLinkFromIp(String ip) { 
            if (this.name.StartsWith("/"))
                this.link = ip + this.name;
            else
                this.link = ip + "/" + this.name;
        }

        public void setLink(String link) { this.link = link; }
        public String getLink() { return link; }
    }
}
