using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace EisenhowerMatrix;

public partial class MainWindow : Window
{
// One collection of tasks per quadrant.
// ObservableCollection automatically updates the ListBox when items change.
    private readonly ObservableCollection<string> doTasks = new();
    private readonly ObservableCollection<string> planTasks = new();
    private readonly ObservableCollection<string> delegateTasks = new();
    private readonly ObservableCollection<string> deleteTasks = new();

    public MainWindow()
    {
        InitializeComponent();
// Connect each ListBox to its collection
        DoList.ItemsSource = doTasks;
        PlanList.ItemsSource = planTasks;
        DelegateList.ItemsSource = delegateTasks;
        DeleteList.ItemsSource = deleteTasks;
    }

    private void AddButton_Click(object? sender, RoutedEventArgs e)
    {
        string text = TaskInput.Text?.Trim() ?? "";
        if (text.Length == 0)
            return; // ignore empty tasks
        bool important = ImportantBox.IsChecked == true;
        bool urgent = UrgentBox.IsChecked == true;
        GetQuadrant(important, urgent).Add(text);
// Reset the inputs for the next task
        TaskInput.Text = "";
        ImportantBox.IsChecked = false;
        UrgentBox.IsChecked = false;
        TaskInput.Focus();
    }

// The Eisenhower rules
    private ObservableCollection<string> GetQuadrant(bool important, bool urgent)
    {
        return (important, urgent) switch
        {
            (true, true)
                => doTasks,
// DO
            (true, false) => planTasks,
// PLAN
            (false, true) => delegateTasks, // DELEGATE
            (false, false) => deleteTasks
// DELETE
        };
    }

// Double-click a task to remove it
    private void List_DoubleTapped(object? sender, TappedEventArgs e)
    {
        if (sender is ListBox list &&
            list.SelectedItem is string task &&
            list.ItemsSource is ObservableCollection<string> tasks)
        {
            tasks.Remove(task);
        }
    }
}