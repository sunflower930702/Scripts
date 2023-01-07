using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class TreasureBoxModel : ObjectModel
{
    public override void myAction() {

        if (addPlayerItem(itemTable, itemId, itemCount) == 0) {
            Destroy(this.gameObject);
        }
    }
}
