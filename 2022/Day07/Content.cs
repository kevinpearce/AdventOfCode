class Content
{
    public string name { get; set; }
    public int size { get; set; }
    public List<Content> children { get; set; } = new List<Content>();

    public Content (string name, string size = "0")
    {
        this.name = name;
        this.size = Int32.Parse(size);
    }

    public void AddChild (Content child)
    {
        this.children.Add(child);
    }

    public int GetSize ()
    { 
        if (this.size > 0){
            return this.size;
        }

        var accumulation = 0; 
        
        foreach (Content child in children)
        {
            accumulation += child.GetSize();
        }

        return accumulation;
    }
}