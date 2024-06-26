﻿using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class TblBookAlert
{
    public int AlertId { get; set; }

    public int? BookDetailId { get; set; }

    public string? ImgProductsBanner { get; set; }

    public string? ImgHomeBanner { get; set; }

    public virtual TblBookDetail? BookDetail { get; set; }
}
