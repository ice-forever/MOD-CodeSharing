using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
namespace 成就MOD一个小目标
{
    public class 成就MOD一个小目标 : MOD
    {
        public 成就MOD一个小目标()
        {
            base.name = "成就MOD一个小目标";
            base.版本 = "Github分享版";
            base.作者 = "失去我的我";
        }
        public 本项目仓库地址="https://github.com/ice-forever/MOD-CodeSharing";
    }
    /*
     * 该段代码参照原版成就：小有成就修改而来。将原版的一百万修改为了一亿
     */
    public class 一个小目标 : 成就基础
    {
        public 一个小目标() : base("一个小目标")
        {
            积分系统.事件_积分变化 += this.积分变化;
        }
        public void 积分变化(用户积分 val)
        {
            if (val.积分 >= this.解锁所需金钱)
            {
                if (成就系统.是否已解锁成就(val.UID, this.成就ID))
                {
                    return;
                }
                成就系统.解锁成就(val.UID, this.成就ID);
            }
        }
        public long 解锁所需金钱 = 100000000L;
    }
}


