using System;
using System.Collections.Generic;

namespace api
{
    public class Data
    {
        public Uri Context { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public About CopyrightHolder { get; set; }
        public Uri License { get; set; }
        public Author Author { get; set; }
        public About About { get; set; }
        public string Description { get; set; }
        public Uri Url { get; set; }
        public string Genre { get; set; }
        public List<DataHasPart> HasPart { get; set; }
        public Breadcrumb Breadcrumb { get; set; }
        public string Headline { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public List<object> ContentTypes { get; set; }
        public List<object> ContentSubTypes { get; set; }
        public List<MainEntityOfPage> MainEntityOfPage { get; set; }
    }

    public class About
    {
        public string Type { get; set; }
        public string Name { get; set; }
    }

    public class Author
    {
        public Uri Url { get; set; }
        public Uri Logo { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }

    public class Breadcrumb
    {
        public Uri Context { get; set; }
        public string Type { get; set; }
        public List<ItemListElement> ItemListElement { get; set; }
    }

    public class ItemListElement
    {
        public string Type { get; set; }
        public long Position { get; set; }
        public Item Item { get; set; }
    }

    public class Item
    {
        public Uri Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
    }

    public class DataHasPart
    {
        public PurpleType Type { get; set; }
        public Uri HasHealthAspect { get; set; }
        public Uri Url { get; set; }
        public string Description { get; set; }
        public List<HasPartHasPart> HasPart { get; set; }
        public string Headline { get; set; }
    }

    public class HasPartHasPart
    {
        public MainEntityOfPageType Type { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
    }

    public class MainEntityOfPage
    {
        public long Identifier { get; set; }
        public MainEntityOfPageType Type { get; set; }
        public Name Name { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
        public List<MainEntityOfPage> MainEntityOfPageMainEntityOfPage { get; set; }
        public string Url { get; set; }
    }

    public enum MainEntityOfPageType
    {
        WebPageElement
    }

    public enum PurpleType
    {
        HealthTopicContent
    }

    public enum Name
    {
        Canonicallinks,
        Link,
        RelatedLinks,
        Toptasks
    }
}