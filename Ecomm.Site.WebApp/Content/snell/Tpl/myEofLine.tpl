<div class="easiorderform_list ">
  <div class="sub_cart_pro">
    <p class="p1 floatleft">
      Product
    </p>
    <p class="p3_cp_pr floatleft textright">
      Price
    </p>
    <p class="p4_forecast floatleft textright">
      Forecast
    </p>
    <p class="p2_qty floatleft">
      Quantity
    </p>
    <p class="clearfloat">
    </p>
  </div>
  {#foreach $T.d as post}
  <div class="sub_cart_list" id="sub{$T.post.ProductID}">
    <p class="sub_cart_img floatleft">
      <a href="product.aspx?pid={$T.post.ProductID}"><img src='{$T.post.SmallPic}' alt='{$T.post.MiddlePic}' class="tip loading" width="136" height="110" border="0" /></a>
    </p>
    <div class="sub_cart_con floatleft">
      <p class="p1">
        <a href="product.aspx?pid={$T.post.ProductID}" class="blue">{$T.post.ProductName}</a>
      </p>
      <p class="p2">
        Code:&nbsp;<span class="blue">{$T.post.ProductNo}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Unit:&nbsp;<span  class="blue">{$T.post.BaseUOFM}
        </span>
      </p>
      <p class="p2">
        Category:&nbsp; <span class="blue">
          {$T.post.CategoryCode}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a href="#" onclick="Remove_favItem('{$T.post.ID}','{$T.post.FavFolderID}','sub{$T.post.ProductID}');">
          <img border="0" src="Themes/ecomm5/images/myeof_delete.png" title="Remove item"/>
		    </a>
      </p>
    </div>
    <div class="floatright cart_list sub_cart_jia" style="width:350px">
      <div class="p2 floatleft">
        <div class="floatleft w_80 textright red">
          $<span class="lPrice">{$T.post.SellPrice}</span>&nbsp;&nbsp;<span class="sp_gst">(+GST)</span>
        </div>
        <div class="floatleft textright">
          <a class="myeof_a_forecast" title="Click add to the Quantity field!">{$T.post.Forecast}</a>
        </div>
        <div class="floatleft span_text">
          <input name="txtQty" type="text" value="" />
			<input type="hidden" name="hdproductID" value="{$T.post.ProductID}"/>
			<input type="hidden" name="hdProductName" value="{$T.post.ProductName}"/>
        </div>
      </div>
      <a class="p4 floatright" title="{$T.post.ProductNo}" name="addCart1" href="javascript:AddToCart();">
      </a>
      <p class="clearfloat">
      </p>
    </div>
    <div class="clearfloat">
    </div>
  </div>
  
</div>