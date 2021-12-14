namespace DevFreela.Application.ViewModels
{
    public class CreateCommentInputModel
    {
        public string Content { get; set; }
        public int IdUser { get; set; }
        public int IdProject { get; set; }
    }
}