using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlborzNirooEnginesObservationAndMonitoringSystem.Models
{
    public class DataModels
    {
        /// <summary>
        /// Part and partnumber definition section
        /// </summary>
        public class PartNumberModel
        {
            [Key]
            public int PartNumberModelId { get; set; }
            public int? NewerPartNumberModelId { get; set; }
            public string PartNumber { get; set; }


        }
        public class PartDefinition
        {
            [Key]
            public int PartDefinitionId { get; set; }
            public string PartDescription { get; set; }


        }
        public class AssemblyPartDefinition
        {
            [Key]
            public int AssemblyPartDefinitionId { get; set; }

            public int? ParentPartDefinitionId { get; set; }
            public virtual AssemblyPartDefinition ParentPartDefinition { get; set; }
            public virtual ICollection<AssemblyPartDefinition> SubPartDefinitions { get; set; }
        }
        public enum TransportCondition
        {
            In = 0,
            Out = 1
        }
        public class Part
        {
            public int AssemblyPartId { get; set; }
            public AssemblyPartDefinition AssemblyPartDefinition { get; set; }
            public string SerialNumber { get; set; }
            public TransportCondition TransportCondition { get; set; }
            public List<Evaluation> Evaluations { get; set; }
        }
        /// <summary>
        /// Third person section
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
        /// Documentation reference section
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
        /// montage demontage definition section
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
        /// project section
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