using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlborzNirooEnginesObservationAndMonitoringSystem.Models
{
    public class DataModels
    {
        /// <summary>
        /// Part and partnumber definition part
        /// </summary>
        public class PartNumberModel
        {
            public int PartNumberId { get; set; }
            public int NewerPartNumberId { get; set; }
            public string PartNumber { get; set; }
        }
        public class PartDefinition
        {
            public int PartDefinitionId { get; set; }
            public string PartDescription { get; set; }
            public PartNumberModel PartNumberModel { get; set; }
            public List<PartNumberModel> SubPartsPartNumberModels { get; set; }
        }
        public enum TransportCondition
        {
            In = 0,
            Out = 1
        }
        public class Part
        {
            public int PartId { get; set; }
            public PartDefinition PartDefinition { get; set; }
            public string SerialNumber { get; set; }
            public TransportCondition TransportCondition { get; set; }
            public List<Evaluation> Evaluations { get; set; }
        }
        /// <summary>
        /// Third person part
        /// </summary>
        public class ThirdPerson
        {
            int ThirdPersonId { get; set; }
            string Name { get; set; }
        }
        public class InSourcePerson : ThirdPerson
        {
            public int ThirdPersonId { get; set; }
            public string Name { get; set; }
        }
        public class Contractor : ThirdPerson
        {
            public int ThirdPersonId { get; set; }
            public string Name { get; set; }
        }
        public class EngineContractor : Contractor
        {
            public List<EngineProject> EngineProjects { get; set; }
        }
        /// <summary>
        /// Documentation reference part
        /// </summary>
        public class DocumentReference
        {
            int ThirdPersonId { get; set; }
            ThirdPerson ThirdPerson { get; set; }
            string ReferenceCode { get; set; }
        }
        public class CheckList : DocumentReference
        {
            public int ThirdPersonId { get; set; }
            public ThirdPerson ThirdPerson { get; set; }
            public string ReferenceCode { get; set; }
        }
        public class MeetingReport : DocumentReference
        {
            public int ThirdPersonId { get; set; }
            public ThirdPerson ThirdPerson { get; set; }
            public string ReferenceCode { get; set; }
        }
        public enum EvaluationResult
        {
            Unknown=0,
            New=1,
            Reuse=2,
            Rebuildable=3,
            Out=4
        }
        public class Evaluation
        {
            public int EvaluationId { get; set; }
            public DateTime EvaluationDate { get; set; }
            public EvaluationResult EvaluationResult { get; set; }
            public List<DocumentReference> DocumentReferences { get; set; }
        }        
        /// <summary>
        /// montage demontage definition
        /// </summary>
        public class XMontage
        {
            int IMontageId { get; set; }
            DateTime StartDate { get; set; }
            DateTime FinishDate { get; set; }
            List<Part> Parts { get; set; }
        }
        public class Montage : XMontage
        {
            public int IMontageId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime FinishDate { get; set; }
            public List<Part> Parts { get; set; }            
        }
        public class Demontage : XMontage
        {
            public int IMontageId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime FinishDate { get; set; }
            public List<Part> Parts { get; set; }
        }
        /// <summary>
        /// project part
        /// </summary>
        public class Project
        {
            public int ContractId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime FinishDate { get; set; }
        }
        public class EngineProject : Project
        {
            public List<XMontage> Demontages { get; set; }
            public List<XMontage> Montages { get; set; }
        }
        
    }
}