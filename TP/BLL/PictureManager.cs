using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class PictureManager
    {
		private readonly IPictureRepository PictureRepository;
		public ICollection<string> errorListAppliedFilter = new List<string>();
		private TimeSpan maxAllowedDuration = TimeSpan.FromSeconds(3);


		public PictureManager(IPictureRepository PictureRepository)
		{
			this.PictureRepository = PictureRepository;
		}

		public ICollection<string> ErrorListAppliedFilter
		{
			get { return errorListAppliedFilter; }
			set { errorListAppliedFilter = value; }
		}

		public bool AppliedListFilterIsEmpty(string pictureName)
		{
			Picture img = new Picture();

			try
			{
				img = PictureRepository.GetById(pictureName);

				errorListAppliedFilter = new List<string>();
				errorListAppliedFilter = img.AppliedFilters;

				if (errorListAppliedFilter.Count > 0)
					return false;
			}
			catch (Exception)
			{
					errorListAppliedFilter = new List<string>();
					errorListAppliedFilter.Add("List null passant par Try/catch");
			}

			return true;
		}
	}
}
