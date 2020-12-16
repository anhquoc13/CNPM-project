using Domain.Entities;
using Application.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.ViewModels
{
    public class AdminViewModel
    {
        public User user { get; set; }
        public PaginatedList<User> userList { get; set; }
        public SelectList roles { get; set; }
        public string UserRole { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
    }
}