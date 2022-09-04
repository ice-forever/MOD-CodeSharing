<h1>需要注意的问题</h1>  

项目框架选择netcoreapp3.1  
NET4.0似乎也能生效

另外，游戏数据修改器的源代码已经公开，希望能有dalao能够参与进来并共同维护和增加新功能。  
[DataModifier4BlindBoxAuction: 为弹幕游戏————盲盒拍卖会设计和开发的游戏数据修改器](https://github.com/ice-forever/DataModifier4BlindBoxAuction)

<h1>在此提供反编译速查信息</h1>  

常用类的反编译结果：  
* [物品属性](#物品属性)
* [箱子属性](#箱子属性)

[代码功能](#功能函数)：
* [成就相关信息的获取](#成就相关信息的获取)

实例代码：
* [enum 标签](#enum标签)
* [委托与事件](#委托与事件)

<h2 id="物品属性">物品属性</h2>

~~~C#
public virtual void 展示物品前(箱子属性 val)
{
}
public virtual void 展示物品后(箱子属性 val)
{
	this.出售后计算市场价格();
	val.展示物品结束(this);
}
public virtual List<物品属性显示.物品属性词缀> 获取词缀()
{
	return this.词缀;
}
protected 物品属性 查找物品(string mod, string name)
{
	name = mod + ":" + name;
	if (字典.物品列表_名称.ContainsKey(name))
	{
		return 字典.物品列表_名称[name].GetComponent<物品属性>();
	}
	return null;
}
protected Transform 物品生成(物品属性 物品, Vector3 坐标 = default(Vector3))
{
	if (this.归属箱子 == null)
	{
		return null;
	}
	return this.归属箱子.生成物品(物品.transform, 坐标);
}
~~~
<h2 id="箱子属性">箱子属性</h2>

~~~ C#
public void 加入箱子(物品属性 物品)
	{
		Transform transform = base.transform.Find("父物体");
		if (transform == null)
		{
			transform = new GameObject("父物体").transform;
		}
		transform.transform.localScale = Vector3.one;
		transform.transform.SetParent(base.transform);
		物品.gameObject.SetActive(true);
		物品.设置归属(this);
		物品.transform.SetParent(transform.transform);
		this.箱子内物品.Add(物品);
	}
public void 重置()
{
	this.箱子内物品 = new List<物品属性>();
	Object.Destroy(base.transform.Find("父物体").gameObject);
}
~~~

<h2 id="功能函数">功能函数</h2>

<h3 id="成就相关信息的获取">成就相关信息的获取</h3>

~~~ c#
public static Dictionary<string, 成就基础> 成就列表_名称 = new Dictionary<string, 成就基础>();
//上面的是数据结构
成就基础 temp = 成就系统.成就列表_名称[成就];
//成就为传入的string；temp变量为获取到的成就信息
成就系统.是否已解锁成就(user.UID,temp.成就ID);
//基于UID判断玩家是否有该成就的函数
~~~


<h2 id="enum标签">public enum 标签</h2>

通过代码补全功能，输入**global**并选择标签。

~~~ c#
//可使用以下模板来设定标签
base.标签 = new System.Collections.Generic.List<标签>
{
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
~~~

<h2 id="委托与事件">委托与事件</h2>

~~~ c#
public static event 拍卖行.委托_结算完毕 事件_结算完毕;
public delegate void 委托_结算完毕(long 利润, long 拍价);
//以上事件提供：当前结算箱子的利润（收入减去竞拍价），竞拍价
public static event 拍卖行.委托_拍卖箱子 事件_拍卖结束一回合;
public delegate void 委托_拍卖箱子(箱子属性 val);
//以上事件提供：当前拍卖的箱子
~~~
~~~C#
//以下是示例的弹幕事件的相关代码
public void 执行事件_弹幕事件(Dm val)
{
	if (事件控制器.事件_弹幕 != null)
	{
		事件控制器.事件_弹幕(val);
	}
}
public static event 事件控制器.委托_弹幕 事件_弹幕;
public delegate void 委托_弹幕(Dm val);
//调用执行事件函数的地方
if (事件控制器.脚本 != null)
{
	事件控制器.脚本.执行事件_弹幕事件(dm);
}
~~~
对比以上思路，我们可以通过反编译在拍卖会类中加入自定义事件
~~~C#
//在该行代码处调用事件
排行榜.脚本.对比排行榜(this.当前竞拍者, num);
~~~
~~~C#
//这是拍卖行类中新增的事件和委托相关代码
public static event 拍卖行.委托_购买者 事件_购买者;
public delegate void 委托_购买者(用户积分 val, long 积分变化);
//调用事件代码如下
if (拍卖行.事件_购买者 != null)
{
	拍卖行.事件_购买者(this.当前竞拍者,num);
}
~~~

<h2 id="图文并茂的专栏">图文并茂的专栏文章</h2>

[盲盒拍卖会MOD制作经验-与箱子利润有关的成就](https://www.bilibili.com/read/cv18111768)


![ice-forever](https://count.getloli.com/get/@:ice-forever?theme=rule34)
