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
      <p class="s_pro_code">
        Code :&nbsp; <span class="blue">{$T.post.ProductNo}</span>
      </p>
      <p class="s_quality">
        <span class="block s_font floatleft">Quantity</span>
        <span class="block s_text floatleft">
          <input name="txtQty" type="text" value="1" />
        </span>
          {#if ($T.post.Item01=="")}
          <a href="javascript:void(0);" title="{$T.post.ProductNo}" name="addCart" class="block s_link floatleft">
            {#else}
            <a href="product.aspx?pid={$T.post.ID}" class="block s_link floatleft"> </a>
            {#/if}
            
          </a>
        <span class="clearfloat block"></span>
      </p>
    </div>
    <p class="clear s_pro_tit">
      <a href="product.aspx?pid={$T.post.ID}" class="clear floatleft">
        {$T.post.ProductName}
      </a>
      <br />
      <span class="blue">
        ${$T.post.SellPrice}
      </span>
      <span class="productThumbImage">
        {#if ($T.post.IsSpecialPrice)}
        <image src="Themes/ecomm5/images/ico.png"/>
        {#/if}
      </span>
    </p>
    <div class="img_description">
      <table border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td width="50">
            {$T.post.Month3}
          </td>
          <td width="50">
            {$T.post.Month2}
          </td>
          <td width="50">
            {$T.post.Month1}
          </td>
          <td width="50">
            {$T.post.Month0}
          </td>
        </tr>
        <tr>
          <td>
            {$T.post.QTY3}
          </td>
          <td>
            {$T.post.QTY2}
          </td>
          <td>
            {$T.post.QTY1}
          </td>
          <td>
            {$T.post.QTY0}
          </td>
        </tr>
      </table>
    </div>
  </li>
  {#if (($P.ind + 1) % 4 == 0)}
  <li class='newline' />
  {#/if}
  {#/for}
</ul>