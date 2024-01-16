using System.Collections.ObjectModel;

namespace GorselProgramlamaOdevFinal_GokhanELALMIS;

public partial class YapilacaklarPage : ContentPage
{
    public ObservableCollection<TodoItem> TodoItems { get; set; }

    public YapilacaklarPage()
    {
        InitializeComponent();

        TodoItems = new ObservableCollection<TodoItem>
        {
        };

        todoListView.ItemsSource = TodoItems;
    }

    private async void OnAddTodoClicked(object sender, System.EventArgs e)
    {
        string newTodo = await DisplayPromptAsync("Yeni TO-DO Ekle", "TO-DO İçeriği");

        if (!string.IsNullOrEmpty(newTodo))
        {
            TodoItems.Add(new TodoItem { Title = newTodo });
        }
    }

    private void OnDeleteClicked(object sender, System.EventArgs e)
    {
        var todo = (TodoItem)((Button)sender).CommandParameter;
        TodoItems.Remove(todo);
    }

    public class TodoItem
    {
        public string Title { get; set; }
    }
}