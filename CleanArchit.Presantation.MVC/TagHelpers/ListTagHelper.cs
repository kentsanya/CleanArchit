using Microsoft.AspNetCore.Razor.TagHelpers;
using CleanArchit.Application.ViewModels;

namespace CleanArchit.Presantation.MVC.TagHelpers
{
    public class ListTagHelper:TagHelper
    {
        public ViewCourseModel ViewCourseModel { get; set; } = new();
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName= "list";
            string listcontent = "<table><theader><tr><td>Name</td><td>Author</td><td>Name</td><td>Operations</td></tr><tbody>";

            foreach (var item in ViewCourseModel.Courses)
            {
                listcontent += $"<tr><td></td>{item.Name}<td></td><td>{item.Author}</td>{item.Description}</tr>";
            }
            listcontent += "</tbody></table>";
            output.Content.SetHtmlContent(listcontent);
        }
    }
}
