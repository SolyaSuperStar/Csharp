using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spam.Interfaces;
using System.Collections;

class VehicleEnum : IEnumerator
{
    private readonly IVehicle[] trans;
    private int index;

    public VehicleEnum(IVehicle[] trans)
    {
        this.trans = trans;
        this.index = 0;
    }

    public bool MoveNext()
    {
        index++;
        return (index < trans.Length);
    }
    public void Reset()
    {
        index = -1;
    }
    object IEnumerator.Current
    {
        get { return Current; }
    }
    private IVehicle Current
    {
        get
        {
            return trans[index];
        }
    }
}
