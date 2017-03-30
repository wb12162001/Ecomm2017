<div class="hide">
  {#param name=mon0 value=eobj.monName[eobj.now.getMonth()]}
  {#param name=mon1 value=eobj.monName[eobj.now.getMonth()-1]}
  {#param name=mon2 value=eobj.monName[eobj.now.getMonth()-2]}
  {#param name=mon3 value=eobj.monName[eobj.now.getMonth()-3]}
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
<ul class="eof_icon_list">
  {#param name=ind value=0}
  {#foreach $T.d as post}
  <li class="wrapper">
	  <a href="product.aspx?pid={$T.post.ProductID}" title="{$T.post.ProductName}" >
      <img src="{$T.post.MiddlePic}" width="210" class="loading pro_icon_img" height="169" border="0" />
    </a>
	  <div class="description">
		  <input type="text" name="txtQty" value="Quantity" title="Quantity"></input>
		  <a href="javascript:void(0);" title="{$T.post.ProductID}" name="addCart">
			  <img src="Themes/ecomm5/images/hoveraddcart.png" width="177" height="49"></img>
		  </a>
	  </div>
	  <p class="clear s_pro_tit">
		  <a href="product.aspx?pid={$T.post.ProductID}" class="clear floatleft font-14">
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
			  <a href="javascript:Addfavorte('{$T.post.ProductID}')"  title="Add to Favourite"  name="addLink">
				  <img src="Themes/ecomm5/images/favoriteico.png"/>
			  </a>
		  </div>
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