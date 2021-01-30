using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CowType {
    BASIC_COW,
    BROWN_COW,
    ALBINO_COW,
    GREEN_COW,
    STUFFED_COW,
    PLACTIC_COW,
    INFLATABLE_COW,
    STATUE_COW,
    CROW_COW,
    CROWN_COW,
    PLANE_COW,
    CHICKEN_COW
};
public class Test_Cow : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite spriteImage;
    public CowType TypeOfCow = CowType.BASIC_COW;
        
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
