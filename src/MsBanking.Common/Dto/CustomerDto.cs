using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MsBanking.Common.Entity;

namespace MsBanking.Common.Dto
{
	public class CustomerDto
	{
        public string FullName { get; set; }
        public long CitizenNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
    
    public class CustomerResponseDto : CustomerDto
    {
        public int Id { get; set; }
    }

	public class CustomerDtoProfile : Profile
	{
		public CustomerDtoProfile()
		{
			CreateMap<CustomerDto, Customer>().ReverseMap();
			CreateMap<CustomerResponseDto, Customer>().ReverseMap();
		}
	}
}
