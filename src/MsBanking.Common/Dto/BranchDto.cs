﻿using AutoMapper;
using MsBanking.Common.Entity;

namespace MsBanking.Common.Dto

{
	public class BranchDto
	{
        public int Code { get; set; }
        public string Name { get; set; }
        public int CityCode { get; set; }
        public int CountryId { get; set; }	

	}

	public class BranchResponseDto : BranchDto
    {
        public int Id { get; set; }
		public string CityName { get; set; }
		public string CountryName { get; set; }


	}

    public class BranchProfile : Profile
    {
        public BranchProfile() 
        {
            CreateMap<Branch,BranchDto>().ReverseMap();
            CreateMap<Branch, BranchResponseDto>()
				.ForMember(x => x.CityName, opt => opt.MapFrom(src => Enum.GetName(typeof(CityEnum), src.CityId)))
				.ForMember(x => x.CountryName, opt => opt.MapFrom(src => Enum.GetName(typeof(CountryEnum), src.CountryId)))
				.ReverseMap();
		}
    }
}
