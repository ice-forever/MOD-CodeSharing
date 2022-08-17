using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
//项目框架请选择netcoreapp3.1
//以下是MOD名称的定义模板
public class MOD名称 : MOD//每个MOD文件夹中最好只有一个DLL且每个MOD文件夹中只允许出现一次MOD名称的定义
{
    public MOD名称()
    {
        base.name = "MOD名称 ";
        base.版本 = "MOD版本";
        base.作者 = "MOD作者";
    }
    public string MOD制作经验分享项目地址 = "https://github.com/ice-forever/MOD-CodeSharing";
}
//以上是MOD名称的定义模板
/*
 * 本文件提供物品、箱子和成就代码的最基础的模板（可通过编译）
 * 可将本文件的模板的代码复制到自己的项目/工程中，经过修改即可成功制作定义了MOD物品，箱子和成就的代码
 * 请多多参考注释内容
 * 也可导入本文件到自己的项目中，本文件使用多个命名空间使得箱子名、物品名和成就名可以重复
 */

namespace 物品//本部分作者指南链接：https://www.bilibili.com/read/cv18052041
{
    //下面的代码是单个物品的模板，请复制这之间的内容来制作多个物品
    public class 物品名称 : 物品属性
    {
        public 物品名称()
        {
            base.名称 = "物品名称";//物品名称需要跟Unity中物品模型名称相同
            base.价格 = 0;
            base.出现概率 = 0.1f;//从0.01f到1f之间均可，f必须加在实数后
            base.标签 = new System.Collections.Generic.List<标签>
            {//在此列举出所有标签，可按需删除。不同标签之间用,隔开
                global::标签.食物,
                global::标签.超市,
                global::标签.普通的,
                global::标签.石头,
                global::标签.矿石,
                global::标签.办公楼,
                global::标签.书,
                global::标签.运动器材,
                global::标签.电子设备,
                global::标签.家庭,
                global::标签.工具,
                global::标签.水果,
                global::标签.武器,
                global::标签.军火,
                global::标签.奢侈品,
                global::标签.宝物,
                global::标签.共鸣,
                global::标签.枪械,
                global::标签.古董
            };
        }
    }
    //上面的代码是单个物品的模板，请复制这之间的内容来制作多个物品
}
namespace 箱子//本部分作者指南链接：https://www.bilibili.com/read/cv18088022
/*
 * 注意，箱子的出率（权重）需要在游戏内修改
 * 如果你只需要自定义时候用到MOD箱子，那么你不需要在DLL中加入箱子定义的代码
 * 箱子的代码实现了随机模式生成MOD箱子的功能
 * 而通过Unity打包的资源中的箱子不会使用DLL中代码，而直接可以在游戏的自定义箱子中出现
 */
{
    //下面的代码是单个箱子的模板，请复制这之间的内容来制作多个箱子
    public class 箱子名称 : 箱子属性
    {
        public 箱子名称()
        {
            base.名称 = "箱子名称";//随机生成的箱子名称，而不是Unity中设定的箱子模型的名称
            base.对应模型名称 = "箱子所用的unity中模型名称";//这里暗示了不需要代码的配置即可在自定义箱子界面选择MOD箱子模型
            //下面的标签表示箱子会随机生成对应标签的物品
            base.标签 = new System.Collections.Generic.List<标签>
            {//在此列举出所有标签，可按需删除。不同标签之间用,隔开
                global::标签.食物,
                global::标签.超市,
                global::标签.普通的,
                global::标签.石头,
                global::标签.矿石,
                global::标签.办公楼,
                global::标签.书,
                global::标签.运动器材,
                global::标签.电子设备,
                global::标签.家庭,
                global::标签.工具,
                global::标签.水果,
                global::标签.武器,
                global::标签.军火,
                global::标签.奢侈品,
                global::标签.宝物,
                global::标签.共鸣,
                global::标签.枪械,
                global::标签.古董
            };
            base.竞拍价 = 0;
        }
    }
    //上面的代码是单个箱子的模板，请复制这之间的内容来制作多个箱子
}

namespace 成就//本部分作者指南链接：https://www.bilibili.com/read/cv18087423
{
    //下面的代码是单个成就的模板，请复制这之间的内容来制作多个成就
    public class 成就名称 : 成就基础//成就名称需要跟Unity中图片的名称相同！
    {
        public 成就名称() : base("成就名称")
        {

        }
    }
    //上面的代码是单个成就的模板，请复制这之间的内容来制作多个成就
}

