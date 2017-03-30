<ul class="eof_icon_list">
	{#param name=ind value=0}
	{#foreach $T.d as post}
	<li class="wrapper">
		{#if ($T.post.Item04!="")}
		<div class="item_top_Promotions"> {$T.post.Item04}</div>
		{#/if}
		<a href="product.aspx?pid={$T.post.ID}" title="{$T.post.ProductName}" >
			<img src="{$T.post.MiddlePic}" width="210" class="loading pro_icon_img" height="169" border="0" />
		</a>
		<div class="description">
			{#if ($T.post.IsSpecialPrice)}
			<span class="producttopImage">
				<img src="Themes/ecomm5/images/specialico.png"/>
			</span>
			{#/if}
			<input type="text" name="txtQty" value="Quantity" title="Quantity"></input>
			{#if ($T.post.Item01=="")}
			<a href="javascript:void(0);" title="{$T.post.ID}" name="addCart">
				<img src="Themes/ecomm5/images/hoveraddcart.png" width="177" height="49"></img>
			</a>
			{#else}
			<a href="product.aspx?pid={$T.post.ID}">
				<img src="Themes/ecomm5/images/hoveraddcart.png" width="177" height="49"></img>
			</a>
			{#/if}
		</div>
		<p class="clear s_pro_tit">
			<a href="product.aspx?pid={$T.post.ID}" class="clear floatleft font-14">
				{$T.post.ProductName}
			</a>
			<div class="leftproductdiv">
				<span class="s_pro_code blue">
					Code :&nbsp; {$T.post.ProductNo}
				</span>
				<span class="red font-14">
					${$T.post.SellPrice} &nbsp;&nbsp;(+GST)
				</span>
			</div>
			<div class="rightproductdiv">
				<a href="javascript:Addfavorte('{$T.post.ID}')"  title="Add to Favourite"  name="addLink">
					<img src="Themes/ecomm5/images/favoriteico.png"/>
				</a>
			</div>
		</p>
	</li>
	{#if (($P.ind + 1) % 4 == 0)}
	<li class='newline' />
	{#/if}
	{#/for}
</ul>