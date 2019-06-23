

using API.DataModels.reports;
using API.Enums;
using System.Collections.Generic;

namespace API.ControllersInterface
{
    public interface IFields
    {
         Fields Get(int Id); 
         List<Fields> GetFieldsByEntity(int entity);
         void SetFields(EntityType fields); 

         void SaveFields(List<FieldValueView> values, int entitypage); 
         void SaveFields(List<FieldValueView> values, MicroValueType type, int typeId); 
         List<FieldValue> GetDependentValues(MicroValueType type, int id); 

         List<FieldValueView> GetFieldValue(MicroValueType type, int epId); 

         EntityType GetEntityById(int id); 
         EntityType GetEntityWithFields(int id);
         List<EntityType> GetEntities(); 
         List<FieldValue> GetFieldValueByFieldAndVersion(int fieldId, int VerisonId);
         List<FieldValue> GetFieldValueByValueTypeAndId(MicroValueType type, int id, int objectId); 
         EntityPages GetEntityPage(int pageId); 
         List<FieldView> GetFieldValue(int epId);

         

    }
}