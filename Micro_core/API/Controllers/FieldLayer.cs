using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Micro_core.DataLayer;
using Micro_core.DataLayer.Attributes;
using Micro_core.DataLayer.Extension;
using Micro_core.DataLayer.Models.Emuns;
using Micro_core.DataLayer.Models.reports;
using Micro_core.IBusinessLayer;
using Micro_core.Models;
using Microsoft.EntityFrameworkCore;

namespace Micro_core.BusinessLayer
{
    public class FieldLayer : IFields
    {

        private readonly IAuditis _audite; 
        public FieldLayer( IAuditis auditi)
        {
            _audite = auditi; 
        }
        public List<FieldValue> GetDependentValues(MicroValueType type, int id)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.FieldValue.Where(x => x.Type == type && x.VerisonId == id && !x.Deleted).ToList();
            }
        }

        public List<Fields> GetFieldsByEntity(int entity)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.Field.Where(x => x.EntityId == entity && !x.Deleted).ToList();
            }
        }

        public void SaveFields(List<FieldValueView> values, int entitypage)
        {
            var ep = GetEntityPageById(entitypage);
            if (ep == null) throw new MicroException("Enity Page Could not be found");

            var version = GetLastestVersion(MicroValueType.Field, ep.PageId);
            if (version == null) throw new MicroException("Entity page has no version yet");

            var fvs = GetFieldValueByValueTypeAndId(MicroValueType.Field, version.Id, ep.PageId);

            var fs = GetFieldsByEntity(ep.EntityId);
            if (fs.Count < 0) throw new MicroException("This entity has no fields yet");

            foreach (var item in values)
            {
                var fv = fvs.Find(x => x.Id == item.ValueId) ??
                 new FieldValue
                 {
                     Type = MicroValueType.Field
                 };

                var f = fs.Find(x => x.Id == item.FieldId);
                if (f == null) continue;

                fv = ExtactValues(f.DataType, fv, item, out var s);
                if (fv == null) continue;

                fv.FieldId = item.FieldId;
                fv.VerisonId = version.Id;
                fv.PageId = ep.PageId;

                SaveOrUpdate(fv, fv.Id);

            }
        }

        ///<summary>
        ///Save field values for all type expect field type
        ///</summary>
        public void SaveFields(List<FieldValueView> values, MicroValueType type, int typeId)
        {
            if(type == MicroValueType.Field) 
            throw new MicroException("You can not save field value using this method"); 

            IVersion v = GetLastestVersion(type, typeId); 
            if(v == null) throw new MicroException("version for this type couldnot be found");

            var fvs = GetFieldValueByValueTypeAndId(type, v.Id, typeId);

            foreach (var item in values)
            {
                
                var fv = fvs.Find(x => x.Id == item.ValueId) ??
                 new FieldValue
                 {
                     Type = type
                 };

                fv = ExtactValues(MicroDataType.Decimal, fv, item, out var s);
                if (fv == null) continue;

                fv.FieldId = item.FieldId;

                var newversion = false; 
                if(fv.VerisonId != v.Id) newversion = true; 

                fv.VerisonId = v.Id;
                fv.PageId = typeId; 

                SaveOrUpdate(fv, newversion ? 0 : fv.Id);

            }
        }
        public FieldValue ExtactValues(MicroDataType type, FieldValue fv, FieldValueView item, out StringBuilder s)
        {
            var changed = false;
            s = new StringBuilder();
            var tChange = "Value changed from ` ||OLD|| ` to ` ||NEW|| `.";
            var tNew = "Value added `||NEW||`";

            switch (type)
            {
                case MicroDataType.IntType:
                    {
                        if (!int.TryParse(item.value, out var v)) return null;

                        if (fv.DecimalValue != v && fv.Id != 0)
                        {
                            changed = true;
                            s.Append(tChange.Replace("||OLD||", fv.DecimalValue.ToString()).Replace("||NEW||", item.value));
                        }
                        else
                        {
                            s.Append(tNew.Replace("||NEW||", item.value));
                        }
                        fv.DecimalValue = v;

                        break;
                    }
                case MicroDataType.Decimal:
                    {
                        if (!decimal.TryParse(item.value, out var v)) return null;
                        if (fv.DecimalValue != v && fv.Id != 0)
                        {
                            changed = true;
                            s.Append(tChange.Replace("||OLD||", fv.DecimalValue.ToString()).Replace("||NEW||", item.value));
                        }
                        else
                        {
                            s.Append(tNew.Replace("||NEW||", item.value));
                        }
                        fv.DecimalValue = v;
                        break;
                    }
                case MicroDataType.DateType:
                    {
                        if (!DateTime.TryParse(item.value, out var v)) return null;
                        if (fv.DateValue != v && fv.Id != 0)
                        {
                            changed = true;
                            s.Append(tChange.Replace("||OLD||", fv.DecimalValue.ToString()).Replace("||NEW||", item.value));
                        }
                        else
                        {
                            s.Append(tNew.Replace("||NEW||", item.value));
                        }
                        fv.DateValue = v;
                        break;
                    }
                case MicroDataType.StringType:
                    {
                        if (fv.StringValue != item.value && fv.Id != 0)
                        {
                            changed = true;
                            s.Append(tChange.Replace("||OLD||", fv.DecimalValue.ToString()).Replace("||NEW||", item.value));
                        }
                        else
                        {
                            s.Append(tNew.Replace("||NEW||", item.value));
                        }
                        fv.StringValue = item.value;
                        break;
                    }
                case MicroDataType.DropdownType:
                    {

                        if (!int.TryParse(item.value, out var v)) return null;
                        if (fv.Selectvalue != v && fv.Id != 0)
                        {
                            changed = true;
                            s.Append(tChange.Replace("||OLD||", fv.DecimalValue.ToString()).Replace("||NEW||", item.value));
                        }
                        else
                        {
                            s.Append(tNew.Replace("||NEW||", item.value));
                        }
                        fv.Selectvalue = v;
                        break;
                    }
            }
           
           if(changed) _audite.System(MicroAuditType.Created, fv.Id, s.ToString());
           
            return fv;
        }
        
        public EntityPages GetEntityPageById(int entitypage)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.EntityPage.FirstOrDefault(x=> x.Id == entitypage); 
            }
        }

        private IVersion GetLastestVersion(MicroValueType type, int pageid)
        {
            using (var ctx = new MicroContext())
            {
                switch (type)
                {
                    case MicroValueType.Field:
                    case MicroValueType.EntityPage:
                    case MicroValueType.Page: 
                    {
                        return ctx.PageVersion
                        .Where(x=> x.PageId == pageid).OrderByDescending(x=> x.Version).FirstOrDefault(); 
                        
                    }
                    case MicroValueType.Report:
                    case MicroValueType.ReportPage:
                    {
                      return ctx.ReportVersion.Where(x=> x.ReportId == pageid)
                      .OrderByDescending(x=> x.Version).FirstOrDefault();
                    }
                    default:
                    return null; 
                }
            }
        }

        private EntityPages GetEntityPage(int pageId, int entityId)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.EntityPage.FirstOrDefault(x => x.EntityId == entityId && x.PageId == pageId);
            }
        }

        public List<FieldValueView> GetFieldValue(MicroValueType type, int epId)
        {
            IVersion v = GetLastestVersion(type,epId); 

            return GetFieldValueByValueTypeAndId(type, v.Id, epId).Select(x=> new FieldValueView{
                value = x.DecimalValue.ToString(),
                ValueId = x.Id,
                dataType = MicroDataType.Decimal,
                FieldId = 0
            }).ToList();
        }
        public List<FieldView> GetFieldValue(int epId)
        {
            var ep = GetEntityPageById(epId);

            IVersion v = GetLastestVersion(MicroValueType.Field, ep.PageId);

            var fvs = GetFieldValueByValueTypeAndId(MicroValueType.Field, v.Id, epId);
            var fs = GetFieldsByEntity(ep.EntityId);
            var list = new List<FieldView>();

            foreach (var item in fs)
            {

                var fv = fvs.Find(x => x.FieldId == item.Id);
                if (fv == null) continue;

                var fvv = new FieldValueView
                {
                    dataType = item.DataType,
                    FieldId = item.Id,
                    ValueId = fv.Id
                };

                switch (item.DataType)
                {
                    case MicroDataType.IntType:
                    case MicroDataType.Decimal:
                        {
                            fvv.value = fv.DecimalValue.ToString();
                            break;
                        }

                    case MicroDataType.DateType:
                        {
                            fvv.value = fv.DateValue?.ToString("d") ?? string.Empty;
                            break;
                        }
                    case MicroDataType.DropdownType:
                        {
                            fvv.value = fv.Selectvalue.ToString();
                            break;
                        }
                    case MicroDataType.StringType:
                        {
                            fvv.value = fv.StringValue;
                            break;
                        }

                }

                list.Add(new FieldView
                {
                    values = fvv,
                    Field = item
                });

            }

            return list;

        }
        public EntityPages GetEntityPage(int pageId)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.EntityPage.FirstOrDefault(x => x.Id == pageId);
            }
        }

        public Fields Get(int fieldId)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.Field.FirstOrDefault(x=> x.Id == fieldId); 
            }
        }

        public List<FieldValue> GetFieldValueByValueTypeAndId(MicroValueType type, int id, int objectId)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.FieldValue.Where(x => x.Type == type && x.VerisonId == id && x.PageId == objectId).ToList();
            }
        }
        public List<FieldValue> GetFieldValueByFieldAndVersion(int fieldId, int VerisonId)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.FieldValue.Where(x => x.FieldId == fieldId && x.VerisonId == VerisonId && !x.Deleted).ToList();
            }
        }
        public void SetFields(EntityType fields)
        {
            var entity = GetEntityById(fields.Id) ?? new EntityType();

            // if (entity.Name == fields.Name && entity.Id == fields.Id)
            //     throw new MicroException("Entitytype name has been used already");

            entity.Name = fields.Name;
            entity.Active = fields.Active;
            entity.Delete = fields.Delete;

            SaveOrUpdate(entity, entity.Id);

            var f = GetFieldsByEntity(entity.Id);
            
            foreach (var item in fields.Fields.OrderBy(x => x.Order))
            {
                var cf = f.Find(x => x.Id == item.Id) ?? new Fields
                {
                    EntityId = entity.Id
                };

                cf.DisplayName = item.DisplayName;
                cf.DataType = item.DataType;
                cf.Order = item.Order;
                cf.Required = item.Required;
                cf.System = item.System;
                cf.Type = item.Type;
                cf.Key = item.Key;

                SaveOrUpdate(cf, cf.Id);


            }

        }

        private void SaveOrUpdate<T>(T objectT, int id) where T : class
        {
            using (var ctx = new MicroContext())
            {
                if (id == 0)
                {
                    ctx.Set<T>().Add(objectT);
                }
                else
                {
                    ctx.Entry<T>(objectT).State = EntityState.Modified;
                }
                ctx.SaveChanges();

            }
        }

        private void saveEntity(EntityType entity)
        {
            using (var ctx = new MicroContext())
            {
                var old = ctx.EntityType.
                AsNoTracking().
                FirstOrDefault(x => x.Id == entity.Id);

                if (old == null)
                {
                    ctx.EntityType.Add(entity);
                }
                else
                {
                    ctx.Entry(entity).State = EntityState.Modified;
                }
                ctx.SaveChanges();

            }
        }

        public EntityType GetEntityById(int id)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.EntityType.FirstOrDefault(x => x.Id == id && !x.Delete);
            }
        }
        
        public EntityType GetEntityWithFields(int id)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.EntityType.
                Include(x=> x.Fields)
                .FirstOrDefault(x => x.Id == id && !x.Delete);
            }
        }

        public void UpdateVersion(int id)
        {
            PageVersion l ;
            using (var ctx = new MicroContext())
            {
                l = ctx.PageVersion
                .Where(x=> x.PageId == id)
                .OrderByDescending(x=> x.Version)
                .FirstOrDefault(); 
            } 
            
            if(l == null) 
            throw new MicroException("Page has no version yet"); 

            if (DateTime.UtcNow.Date != DateTime.UtcNow.LastDayOfMonth())
                throw new MicroException("Version can only be added if its the end of the month");

            if (l.Date.Month == DateTime.UtcNow.Month)
                throw new MicroException("Only one version can be add per month");

            ++l.Version;
            l.Id = 0;

            SaveOrUpdate(l, 0);
        }

        public List<EntityType> GetEntities()
        {
            using (var ctx = new MicroContext())
            {
                return ctx.EntityType.Where(x=> !x.Delete)
                .Include(x=> x.Fields).ToList();
            }
        }

    }
}