using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlantModel : ObjectModel
{
    public override void myAction() {

        if (addPlayerItem(itemTable, itemId, itemCount) == 0) {
            if (isDestory) {
                Destroy(this.gameObject);
            }
        }
    }
}
