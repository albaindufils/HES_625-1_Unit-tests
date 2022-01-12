using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class PictureManager
    {
		private readonly IPictureRepository PictureRepository;
		public List<string> ListAppliedFilter = new List<string>();
		private TimeSpan maxAllowedDuration = TimeSpan.FromSeconds(3);


		public PictureManager(IPictureRepository PictureRepository)
		{
			this.PictureRepository = PictureRepository;
		}

		public void AddInlistAppliedFilter (string FilterName)
		{
			Picture img = new Picture();

			ListAppliedFilter = img.AppliedFilters;

			ListAppliedFilter.Add(FilterName);

			img.AppliedFilters = ListAppliedFilter;

		}

		public bool AppliedListFilterIsEmpty(string pictureName)
		{
			Picture img = new Picture();

			try
			{
				img = PictureRepository.GetById(pictureName);

				ListAppliedFilter = new List<string>();
				ListAppliedFilter = img.AppliedFilters;

				if (ListAppliedFilter.Count > 0)
					return false;
			}
			catch (Exception)
			{
				AddInlistAppliedFilter("List null passant par Try/catch");
			}

			return true;
		}
	}
}
