using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Donea_Paul_App.Data;

namespace Donea_Paul_App.Models
{
    public class TruckCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Donea_Paul_AppContext context, Truck truck)
        {
            var allCategories = context.Category;
            var bookCategories = new HashSet<int>(truck.TruckCategories.Select(c => c.TruckID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.ID)
                });

            }

        }
        public void UpdateBookCategories(Donea_Paul_AppContext context, string[] selectedCategories, Truck truckToUpdate)
        {
            if (selectedCategories == null)
            {
                truckToUpdate.TruckCategories = new List<TruckCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (truckToUpdate.TruckCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        truckToUpdate.TruckCategories.Add(
                        new TruckCategory
                        {
                            TruckID = truckToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        TruckCategory courseToRemove
                        = truckToUpdate
                        .TruckCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);



                    }
                }

            }
        }
    }
}


