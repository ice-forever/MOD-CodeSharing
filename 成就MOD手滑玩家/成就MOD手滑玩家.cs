using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
namespace 成就MOD手滑玩家
{
    public class 成就MOD手滑玩家 : MOD
    {
        public 成就MOD手滑玩家()
        {
            base.name = "成就MOD手滑玩家";
            base.版本 = "Github分享版";
            base.作者 = "失去我的我";
        }
    }
    /*
     * 本MOD代码实现需要对Assembly-CSharp.dll文件进行反编译修改
     * 反编译可能导致游戏运行不稳定，请谨慎选择是否使用此思路！
     * 反编译思路说明请参见https://github.com/ice-forever/MOD-CodeSharing仓库的README文件
     * 以下列出反编译添加的代码
     * //这是拍卖行类中新增的事件和委托相关代码
     * public static event 拍卖行.委托_购买者 事件_购买者;
     * public delegate void 委托_购买者(用户积分 val, long 积分变化);
     * //调用事件代码如下
     * if (拍卖行.事件_购买者 != null)拍卖行.事件_购买者(this.当前竞拍者,num);
     * //在该行代码前添加上一行调用事件代码
     * 排行榜.脚本.对比排行榜(this.当前竞拍者, num);
     */
    public class 手滑玩家 : 成就基础
    {
        public 手滑玩家():base("手滑玩家")
        {
            拍卖行.事件_购买者 += 检查;//此处事件由反编译提供！
        }
        public void 检查(用户积分 val,long num)
        {
            if (!成就系统.是否已解锁成就(val.UID, this.成就ID))
            {
                if (num <= -200000L)
                {
                    成就系统.解锁成就(val.UID, this.成就ID);
                }
            }
        }
    }
}


