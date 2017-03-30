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

<div class="easiorderform_list ">
  <div class="sub_cart_pro">
    <p class="p1 floatleft">
      Product
    </p>
    <p class="p3_cp_pr floatleft text-center">
      Price
    </p>
    <p class="p2_qty floatleft">
      Quantity
    </p>
    <p class="clearfloat">
    </p>
  </div>
  {#foreach $T.d as post}
  <div class="sub_cart_list">
    <p class="sub_cart_img floatleft">
      <a href="product.aspx?pid={$T.post.ProductID}">
        <img src="{$T.post.SmallPic}" alt="{$T.post.MiddlePic}"
            class="tip loading" width="136" height="110" border="0" />
      </a>
    </p>
    <div class="sub_cart_con floatleft">
      <p class="p1">
        <a href="product.aspx?pid={$T.post.ProductID}" class="blue">
          {$T.post.ProductName}
        </a>
      </p>
      <p class="p2">
        Code:  <span class="blue"> {$T.post.ProductNo}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Unit:&nbsp;<span
                                class="blue">{$T.post.BaseUOFM}</span>
      </p>
      <p class="p3">
        Category: <span class="blue">
          {$T.post.ProdCategoryCode}
        </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a href="javascript:Addfavorte('{$T.post.ProductID}')" title="Add to Favourite" name="addLink">
          <img border="0" src="Themes/ecomm5/images/favoriteico.png" />
        </a>
      </p>
    </div>

    <div class="floatright cart_list sub_cart_jia" style="width:350px;">
      <p class="p2 floatleft">
        <span class="floatleft w_80 textright red">
          $<span class="lPrice">{$T.post.ClearPrice}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </span>
        <span class="floatleft span_text ">
          <input name="txtQty" type="text" value="" />
        </span>
        <span class="clearfloat"></span>
      </p>
      <a class="p4 floatright" title="{$T.post.ProductID}" name="addCart" href="javascript:void(0);">
      </a>
      <p class="clearfloat">
      </p>
    </div>
    <div class="clearfloat">
    </div>
  </div>

</div>