using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserTask.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "DueDate is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DueDate { get; set; }
        
        public int Prioritylevel { get; set; }
        
        public int Status { get; set; }

        public string StatusDescripton
        {
            get
            {
                TaskType type = Statuses.Where(i => i.Id == Status).FirstOrDefault();
                if (type != null)
                {
                    return type.Value;
                } 
                else
                {
                    return string.Empty;
                }
            }
        }

        public string PriorityLevelDescripton { 
            get {
                TaskType type = PriorityLevels.Where(i => i.Id == Prioritylevel).FirstOrDefault();
                if (type != null)
                {
                    return type.Value;
                }
                else
                {
                    return string.Empty;
                }
            } 
        }

        public List<TaskType> PriorityLevels {
            get     
            { 
                List<TaskType> _priorityLevels = new List<TaskType>();
                _priorityLevels.Add(new()
                {
                    Id = 1,
                    Value = "low"
                });
                _priorityLevels.Add(new()
                {
                    Id = 2,
                    Value = "medium"
                });
                _priorityLevels.Add(new()
                {
                    Id = 3,
                    Value = "high"
                });
                _priorityLevels.Add(new()
                {
                    Id = 4,
                    Value = "maximum"
                });
                return _priorityLevels; 
            } 
        }

        public List<TaskType> Statuses { 
            get
            { 
                List<TaskType> _priorityLevels = new List<TaskType>();
                _priorityLevels.Add(new()
                {
                    Id = 1,
                    Value = "created"
                });
                _priorityLevels.Add(new()
                {
                    Id = 2,
                    Value = "in progress"
                });
                _priorityLevels.Add(new()
                {
                    Id = 3,
                    Value = "completed"
                });
                return _priorityLevels; 
            } 
        }
        public List<SelectListItem> PriorityLevelsSelect { get
            {
                List<SelectListItem> list = PriorityLevels.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.Id.ToString(),
                                              Text = a.Value
                                          }).ToList();

                SelectListItem item = list.Where(i => i.Value == Prioritylevel.ToString()).FirstOrDefault();
                if (item != null)
                {
                    item.Selected = true;
                }
                return list;
            }
        }
        public List<SelectListItem> StatusesSelect { get {
               List<SelectListItem> list = Statuses.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.Id.ToString(),
                                              Text = a.Value
                                          }).ToList();

                SelectListItem item = list.Where(i => i.Value == Status.ToString()).FirstOrDefault();
                if (item != null)
                {
                    item.Selected = true;
                }
                return list;
            } 
        }
    }
}
