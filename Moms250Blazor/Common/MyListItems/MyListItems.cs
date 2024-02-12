namespace Moms250Blazor.Common;

public class MyListItems
{
    public MyListItems() { }
    public MyListItems(object value, string text) : this()
    {
        Text = text;
        if (value is bool b)
            B = b;
        if (value is int i)
            I = i;
        else if (value is string s)
            S = s;
        else if (value is Guid g)
            G = g;
    }
    public bool? B { get; set; } = null!;
    public int? I { get; set; } = null!;
    public string? S { get; set; } = null!;
    public Guid? G { get; set; } = null!;
    public string Text { get; set; } = "";
    public string? Attrb1 { get; set; } = null!;
    public string? Attrb2 { get; set; } = null!;
    public string? Attrb3 { get; set; } = null!;
    public string? Attrb4 { get; set; } = null!;
}
