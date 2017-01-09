using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameBoardModel : Model {
    public float LeftTime;
    public float Score;
    public float LastSpawnTime = -1f;
    public ModelRefs<JellyFishModel> JellyFishs;
}
