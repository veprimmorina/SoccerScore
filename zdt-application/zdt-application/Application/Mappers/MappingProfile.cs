using AutoMapper;
using zdt_application.DTOs;
using zdt_application.DTOs.Matches;
using zdt_application.Models;

namespace zdt_application.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserResultPrediction, UserPredictionDto>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && !IsDefaultValue(srcMember)));

            CreateMap<MostClickedMatch, MostClickedMatchDto>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && !IsDefaultValue(srcMember)));

            CreateMap<MatchRating, MatchRatingDto>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && !IsDefaultValue(srcMember)));
        }

        private bool IsDefaultValue(object value)
        {
            if (value == null) return true;

            var type = value.GetType();
            if (!type.IsValueType) return false;

            return value.Equals(Activator.CreateInstance(type));
        }
    }
}