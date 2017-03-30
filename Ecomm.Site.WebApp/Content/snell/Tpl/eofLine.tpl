<div class="hide">
	{#param name=mon0 value=eobj.monName[getMonth(0)]}
	{#param name=mon1 value=eobj.monName[getMonth(1)]}
	{#param name=mon2 value=eobj.monName[getMonth(2)]}
	{#param name=mon3 value=eobj.monName[getMonth(3)]}
	{#param name=mon4 value=eobj.monName[getMonth(4)]}
	{#param name=show value=eobj.showModle}
	{#param name=sort value=eobj.sortName}
	{#param name=desc value=eobj.sortModle}
	{#param name=loca value=eobj.location}
	{#param name=cate value=eobj.category}
	show: {$P.show}<br>
		sort: {$P.sort}<br>
			desc: {$P.desc}<br>
				loca: {$P.loca}<br>
					cate: {$P.cate}<br>
</div>

<div class="easiorderform_list {#if $P.show == 0}hide{#/if}">
	<div class="sub_cart_pro">
                        <div class="p1 floatleft">
							Product</div>
						
		<div class="sub_pro_header floatright">
			<p class="p3 floatleft textright">
				{$P.mon4}
			</p>
			<p class="p3 floatleft textright">
				{$P.mon3}
			</p>
			<p class="p3 floatleft textright">
				{$P.mon2}
			</p>
			<p class="p3 floatleft textright">
				{$P.mon1}
			</p>
			<p class="p3 floatleft textright">
				{$P.mon0}
			</p>
			<p class="p1 floatleft textright">
				Price
			</p>
      <p class="p1 floatleft textright">
        Forecast
      </p>
			<p class="p1 floatleft textright">
				Quantity
			</p>
			<!--<p class="w_80 floatleft">
			</p>-->     
		</div>
                    </div>
{#foreach $T.d as post}
                <div class="sub_cart_list">
                    <p class="sub_cart_img floatleft">
						<a href="product.aspx?pid={$T.post.ProductID}">
                            <img src="{$T.post.SmallPic}" alt="{$T.post.MiddlePic}"
                                class="tip loading" width="136" height="110" border="0" /></a>
                    </p>
                    <div class="sub_cart_con floatleft">
                        <p class="p1">
                            <a href="product.aspx?pid={$T.post.ProductID}" class="blue">
                                {$T.post.ProductName}</a></p>
                        <p class="p2">
                          Code:  <span class="blue"> {$T.post.ProductNo}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Unit:&nbsp;<span
                                class="blue">{$T.post.BaseUOFM}</span></p>
                        <p class="p3">
                          Category: <span class="blue cate_code">
                               {$T.post.ProdCategoryCode}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <a href="javascript:Addfavorte('{$T.post.ProductID}')" title="Add to Favourite" name="addLink">
                          <img border="0" src="Themes/ecomm5/images/favoriteico.png" />
                        </a>
                          </p>
                    </div>
                    <div class="sub_cart_con1">
                      <img class="tipImg" style="cursor:pointer;" alt="{$T.post.altPath}" src="../../Themes/ecomm5/images/GraphMain.png" />
                      
                    </div>
                    <div class="floatright sub_cart_easi">
						<p class="p2 floatleft textright">
							{$T.post.QTY4}
						</p>
						<p class="p2 floatleft textright">
							{$T.post.QTY3}
						</p>
						<p class="p2 floatleft textright">
							{$T.post.QTY2}
						</p>
						<p class="p2 floatleft textright">
							{$T.post.QTY1}
						</p>
						<p class="p2 floatleft textright">
							{$T.post.QTY0}
						</p>
						<p class="p2 floatleft price_txt textright red">
							$<span class="lPrice">{$T.post.SellPrice}</span>&nbsp;&nbsp;<span class="sp_gst" style="display:block">(+GST)</span>
						</p>
             <p class="p2 floatleft" style="text-align:center;" name="eof_Forecast" title="Click add to the Quantity field!">
               <a>{$T.post.Forecast}</a>
             </p>
						<p class="p2 floatleft es_text1">
							<input name="txtQty" type="text" value="" />
							<input type="hidden" name="hdproductID" value="{$T.post.ProductID}"/>
							<input type="hidden" name="hdProductName" value="{$T.post.ProductName}"/>
						</p>
						<!--<p class="p2 floatright addtoCart">
							<a title="{$T.post.ProductNo}" name="addCart" href="javascript:void(0);">
								<img src="Themes/ecomm5/images/cart_add.png" border="0" />
							</a>
						</p>-->
					</div>
                    <div class="clearfloat">
                    </div>
                </div>
{#/for}
                </div>