using APIAnimeApp.Dto;
using APIAnimeApp.Model;
using AutoMapper;

namespace APIAnimeApp.Helper
{
	public class MappingProfiles:Profile
	{
		public MappingProfiles()
		{
			CreateMap<Story, StoryDto>()
				.ForMember(dest => dest.Author, otp => otp.MapFrom(src => src.Author==""?"Đang cập nhật":src.Author))
				.ForMember(dest => dest.Category, otp => otp.MapFrom(src => src.IdCategoryNavigation.Name))
				.ForMember(dest => dest.numOfChapter, otp => otp.MapFrom(src => src.Chapters.Count()));
			CreateMap<Chapter, ChapterDto>();
			CreateMap<Page, PageDto>();
			CreateMap<Category, CategoryDto>();
			CreateMap<Comment, CommentDto>();
			CreateMap<CommentDto, Comment>();
		}
	}
}
