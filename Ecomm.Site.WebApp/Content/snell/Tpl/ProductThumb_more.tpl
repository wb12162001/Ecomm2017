
<ul class="pro_icon_list2">
  {#param name=ind value=0}
  {#foreach $T.d as post}
  <li class="wrapper">
    <a href="product.aspx?pid={$T.post.ProductID}" title="{$T.post.ProductName}" >
      <img src="{$T.post.SmallPic}" width="100" class="loading pro_icon_img" height="89" border="0" />
    </a>
    
    

     <div class="Picdescription">
                    <p class="s_pro_tit">
                        <a href="product.aspx?pid={$T.post.ProductID}">
                            {$T.post.ProductName}</a>
                        <!--<span class="red" style="display:block;"></span>-->
                    </p>
                    <p class="red font-12">${$T.post.SellPrice}&nbsp;&nbsp;(+GST)</p>
                    <p class="s_pro_code">
                        Code :&nbsp;<span>
                            {$T.post.ProductNo}</span>
                    </p>
                    <p class="s_quality">
                        <span class="block s_font floatleft font-12">Qty</span><span class="block s_text floatleft">
                            <input name="txtQty" type="text" value="1" /></span>
                      {#if ($T.post.Item01=="")}
                          <a href="javascript:void(0);" title="{$T.post.ProductID}" name="addCart" class="block s_link floatleft">
                      {#else}
                        <a href="product.aspx?pid={$T.post.ProductID}" class="block s_link floatleft"> </a>
                      {#/if}


                      </a>
                      
                        <span class="clearfloat block"></span>
                    </p>
     </div>


  </li>
  {#if (($P.ind + 1) % 6 == 0)}
  <li class='newline' />
  {#/if}
  {#/for}
</ul>