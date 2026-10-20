using UnityEngine;

public class OrganicWaste : WasteItem
{
    protected override void Collect()
    {
        info = "Organik: olah menjadi kompos (+" + pointValue + " poin)";
        base.Collect();
    }
}
