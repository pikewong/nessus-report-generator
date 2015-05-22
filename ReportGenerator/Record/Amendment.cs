using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator.Record
{
    public class Amendment
    {
        private string id;
        private string entryType;
        private string originalDescription;
        private string editedDescription;
        private string originalRecommendation; 
        private string editedRecommendation;
        private string originalReferenceLink;
        private string editedReferenceLink;

        public Amendment(string id, string entryType, string originalDescription, string editedDescription, string originalRecommendation, string editedRecommendation, string originalReferenceLink, string editedReferenceLink)
        {
            this.id = id;
            this.entryType = entryType;
            this.originalDescription = originalDescription;
            this.editedDescription = editedDescription;
            this.originalRecommendation = originalRecommendation;
            this.editedRecommendation = editedRecommendation;
            this.originalReferenceLink = originalReferenceLink;
            this.editedReferenceLink = editedReferenceLink;

        }



        public string getId()
        {
            return id;
        }

        public string getEntryType()
        {
            return entryType;
        }

        public string getEditedDescription()
        {
            return editedDescription;
        }

        public string getOriginalDescription()
        {
            return originalDescription;
        }

        public string getOriginalRecommendation()
        {
            return originalRecommendation;
        }

        public string getEditedRecommendation()
        {
            return editedRecommendation;
        }

        public string getOriginalReferenceLink()
        {
            return originalReferenceLink;
        }
        public string getEditedReferenceLink()
        {
            return editedReferenceLink;
        }
    }
}
