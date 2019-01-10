using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlborzNirooEnginesObservationAndMonitoringSystem.Models
{
    public class DataModels
    {
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
        public interface IThirdPerson
        {
            int ThirdPersonId { get; set; }
            string Name { get; set; }
        }
        public class InSourcePerson : IThirdPerson
        {
            public int ThirdPersonId { get; set; }
            public string Name { get; set; }
        }
        public interface IDocumentReference
        {
            int ThirdPersonId { get; set; }
            IThirdPerson ThirdPerson { get; set; }
            string ReferenceCode { get; set; }
        }
        public class CheckList : IDocumentReference
        {
            public int ThirdPersonId { get; set; }
            public IThirdPerson ThirdPerson { get; set; }
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
            public List<IDocumentReference> DocumentReferences { get; set; }
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
        public interface IMontage
        {
            int IMontageId { get; set; }
            DateTime StartDate { get; set; }
            DateTime FinishDate { get; set; }
            List<Part> Parts { get; set; }
        }
        public class Montage : IMontage
        {
            public int IMontageId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime FinishDate { get; set; }
            public List<Part> Parts { get; set; }            
        }
        public class Demontage : IMontage
        {
            public int IMontageId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime FinishDate { get; set; }
            public List<Part> Parts { get; set; }
        }
        public class Project
        {
            public int ContractId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime FinishDate { get; set; }
        }
        public class EngineProject : Project
        {
            public List<IMontage> Demontages { get; set; }
            public List<IMontage> Montages { get; set; }
        }

        public class Contractor : IThirdPerson
        {
            public int ThirdPersonId { get; set; }
            public string Name { get; set; }
        }
        public class EngineContractor : Contractor
        {
            public List<EngineProject> EngineProjects { get; set; }
        }
    }
}