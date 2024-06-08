using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameInput
{
    public partial class InputInHome  {
       private static InputInHome _instance;

       public static InputInHome instance {
        get {
            if (_instance == null) {
                _instance = new InputInHome();
                _instance.Enable();
            }

            return _instance;
        }
        private set => _instance = value;
       } 
    }
}

