﻿namespace WatchStore.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<CartEntry> CartEntries { get; set; } = new List<CartEntry>();
    }
}
