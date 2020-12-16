using System.Collections.Generic;
using Application.DTO;
using Domain.Entities;

namespace Application.Mappings
{
    public static class FolderMapper
    {
        public static FolderDto MappingDto(this Folder Folder)
        {
            return new FolderDto
            {
                ID = Folder.ID,
                IDuser = Folder.IDuser,
                name = Folder.name,
                describe = Folder.describe,
                link = Folder.link
            };
        }

        public static Folder MappingFolder(this FolderDto FolderDto)
        {
            return new Folder
            {
                ID = FolderDto.ID,
                IDuser = FolderDto.IDuser,
                name = FolderDto.name,
                describe = FolderDto.describe,
                link = FolderDto.link
            };
        }

        public static void MappingFolder(this FolderDto FolderDto, Folder Folder)
        {
            Folder.ID = FolderDto.ID;
            Folder.IDuser = FolderDto.IDuser;
            Folder.name = FolderDto.name;
            Folder.describe = FolderDto.describe;
            Folder.link = FolderDto.link;
        }

        public static IEnumerable<FolderDto> MappingDto(this IEnumerable<Folder> Folders)
        {
            foreach (var Folder in Folders)
            {
                yield return Folder.MappingDto();
            }
        }

        public static IEnumerable<Folder> MappingFolder(this IEnumerable<FolderDto> FolderDtos)
        {
            foreach (var FolderDto in FolderDtos)
            {
                yield return FolderDto.MappingFolder();
            }
        }

    }
}
