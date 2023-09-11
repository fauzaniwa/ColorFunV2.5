using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenfessManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> menfesTamplateList;
    [SerializeField] private MenfessController menfessController;

    private void Start()
    {
        SpawnMenfes();
    }

    private void SpawnMenfes()
    {
        var obj = Instantiate(menfesTamplateList[0]);
        menfessController = obj.GetComponent<MenfessController>();
    }

    public void SaveMenfess()
    {
        Animator anim = menfessController.GetComponent<Animator>();

        anim.SetBool("finish", true);
    }
}
