using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Components
{
    interface IOpponentAI
    {


        void StartAttack( );

        void FinishAttack( );

        int GetAttackTime( );

        void SetAttackTime(int time);
    }
}
