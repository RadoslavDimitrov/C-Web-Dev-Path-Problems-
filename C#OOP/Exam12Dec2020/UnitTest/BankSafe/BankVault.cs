using BankSafe;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

public class BankVault
{
    private readonly Dictionary<string, Item> vaultCells;
    //TODO test -
    public BankVault()
    {
        this.vaultCells = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
    }
    //TODO test -
    public IReadOnlyDictionary<string, Item> VaultCells
        => this.vaultCells.ToImmutableDictionary();

    public string AddItem(string cell, Item item)
    {
        if (!this.vaultCells.ContainsKey(cell))
        {
            //TODO test done
            throw new ArgumentException("Cell doesn't exists!");
        }

        if (this.vaultCells[cell] != null)
        {
            //TODO test done
            throw new ArgumentException("Cell is already taken!");
        }

        bool cellExists = this.vaultCells.Values
            .Any(x => x?.ItemId == item.ItemId);

        if (cellExists)
        {
            //TODO test done
            throw new InvalidOperationException("Item is already in cell!");
        }
        //TODO test
        this.vaultCells[cell] = item;
        //TODO test done
        return $"Item:{item.ItemId} saved successfully!";
    }

    public string RemoveItem(string cell, Item item)
    {
        if (!this.vaultCells.ContainsKey(cell))
        {//TODO test
            throw new ArgumentException("Cell doesn't exists!");
        }

        if (this.vaultCells[cell] != item)
        {
            //TODO test
            throw new ArgumentException($"Item in that cell doesn't exists!");
        }
        //TODO test
        this.vaultCells[cell] = null;
        //TODO test
        return $"Remove item:{item.ItemId} successfully!";
    }
}