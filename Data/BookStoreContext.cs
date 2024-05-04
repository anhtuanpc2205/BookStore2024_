using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStore2024.Data;

public partial class BookStoreContext : DbContext
{
    public BookStoreContext()
    {
    }

    public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAuthor> TblAuthors { get; set; }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    public virtual DbSet<TblBook> TblBooks { get; set; }

    public virtual DbSet<TblBookAlert> TblBookAlerts { get; set; }

    public virtual DbSet<TblBookDetail> TblBookDetails { get; set; }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblFormat> TblFormats { get; set; }

    public virtual DbSet<TblGenre> TblGenres { get; set; }

    public virtual DbSet<TblNewReleaseBook> TblNewReleaseBooks { get; set; }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserWishlist> TblUserWishlists { get; set; }

    public virtual DbSet<UserWishlist> UserWishlists { get; set; }

    public virtual DbSet<ViewAuthorDetail> ViewAuthorDetails { get; set; }

    public virtual DbSet<ViewBlogDetail> ViewBlogDetails { get; set; }

    public virtual DbSet<ViewBookAlert> ViewBookAlerts { get; set; }

    public virtual DbSet<ViewBookDetail> ViewBookDetails { get; set; }

    public virtual DbSet<ViewNewReleaseBook> ViewNewReleaseBooks { get; set; }

    public virtual DbSet<ViewOrderDetail> ViewOrderDetails { get; set; }

    public virtual DbSet<ViewTop20BestSellingBook> ViewTop20BestSellingBooks { get; set; }

    public virtual DbSet<ViewTopBloger> ViewTopBlogers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BookStore;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAuthor>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__tbl_Auth__86516BCFA1A5325C");

            entity.ToTable("tbl_Author");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.AuthorDescription).HasColumnName("author_description_");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(255)
                .HasColumnName("author_name");
            entity.Property(e => e.ProfileImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profile_image_url");
        });

        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__tbl_Blog__2975AA28B704E155");

            entity.ToTable("tbl_Blog");

            entity.Property(e => e.BlogId).HasColumnName("blog_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BlogDescription)
                .HasMaxLength(255)
                .HasColumnName("blog_description_");
            entity.Property(e => e.BlogTitle)
                .HasMaxLength(255)
                .HasColumnName("blog_title");
            entity.Property(e => e.Content).HasColumnName("content_");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("img_url");
            entity.Property(e => e.Views)
                .HasDefaultValue(0)
                .HasColumnName("views_");

            entity.HasOne(d => d.Author).WithMany(p => p.TblBlogs)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Blog_author_id");
        });

        modelBuilder.Entity<TblBook>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__tbl_Book__490D1AE130349450");

            entity.ToTable("tbl_Book");

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BookDescription).HasColumnName("book_description_");
            entity.Property(e => e.BookImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("book_image_url");
            entity.Property(e => e.BookTitle)
                .HasMaxLength(255)
                .HasColumnName("book_title");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.IllustrationsNote)
                .HasMaxLength(255)
                .HasColumnName("Illustrations_note");
            entity.Property(e => e.Language)
                .HasMaxLength(30)
                .HasColumnName("language_");
            entity.Property(e => e.Publisher).HasMaxLength(255);

            entity.HasOne(d => d.Author).WithMany(p => p.TblBooks)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_author_id");

            entity.HasOne(d => d.Category).WithMany(p => p.TblBooks)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_category_id");

            entity.HasOne(d => d.Genre).WithMany(p => p.TblBooks)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Genre_id");
        });

        modelBuilder.Entity<TblBookAlert>(entity =>
        {
            entity.HasKey(e => e.AlertId).HasName("PK__tbl_book__4B8FB03AC78F1D8E");

            entity.ToTable("tbl_book_alert");

            entity.Property(e => e.AlertId).HasColumnName("alert_id");
            entity.Property(e => e.BookDetailId).HasColumnName("book_Detail_id");
            entity.Property(e => e.ImgHomeBanner)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("img_home_banner");
            entity.Property(e => e.ImgProductsBanner)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("img_products_banner");

            entity.HasOne(d => d.BookDetail).WithMany(p => p.TblBookAlerts)
                .HasForeignKey(d => d.BookDetailId)
                .HasConstraintName("FK_book_alert");
        });

        modelBuilder.Entity<TblBookDetail>(entity =>
        {
            entity.HasKey(e => e.BookDetailId).HasName("PK__tbl_Book__6DDA91DFCFC47174");

            entity.ToTable("tbl_Book_Detail");

            entity.Property(e => e.BookDetailId).HasColumnName("book_Detail_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.Discount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.FormatId).HasColumnName("format_id");
            entity.Property(e => e.Isbn10)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISBN10");
            entity.Property(e => e.Isbn13)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISBN13");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.StockQuantity).HasColumnName("stock_quantity");
            entity.Property(e => e.Views)
                .HasDefaultValue(0)
                .HasColumnName("views_");

            entity.HasOne(d => d.Book).WithMany(p => p.TblBookDetails)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bookDetail");

            entity.HasOne(d => d.Format).WithMany(p => p.TblBookDetails)
                .HasForeignKey(d => d.FormatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bookDetail_Format_");
        });

        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__tbl_Cate__D54EE9B4214FB1FF");

            entity.ToTable("tbl_Category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<TblFormat>(entity =>
        {
            entity.HasKey(e => e.FormatId).HasName("PK__tbl_Form__26B11DF1D76C86D4");

            entity.ToTable("tbl_Format");

            entity.Property(e => e.FormatId).HasColumnName("format_id");
            entity.Property(e => e.FormatName)
                .HasMaxLength(50)
                .HasColumnName("format_name");
        });

        modelBuilder.Entity<TblGenre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__tbl_Genr__18428D42EA718CBC");

            entity.ToTable("tbl_Genre");

            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.GenreName)
                .HasMaxLength(50)
                .HasColumnName("genre_name");
        });

        modelBuilder.Entity<TblNewReleaseBook>(entity =>
        {
            entity.HasKey(e => e.NewReleaseId).HasName("PK__tbl_new___8258F1F4A5E8FFE1");

            entity.ToTable("tbl_new_release_books");

            entity.Property(e => e.NewReleaseId).HasColumnName("new_release_id");
            entity.Property(e => e.BookDetailId).HasColumnName("book_Detail_id");

            entity.HasOne(d => d.BookDetail).WithMany(p => p.TblNewReleaseBooks)
                .HasForeignKey(d => d.BookDetailId)
                .HasConstraintName("FK_new_release");
        });

        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__tbl_Orde__46596229ACC2197B");

            entity.ToTable("tbl_Order");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("order_status");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(255)
                .HasColumnName("shipping_address");
            entity.Property(e => e.ShippingFee)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("shipping_fee");
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(100)
                .HasColumnName("shipping_method");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id_");

            entity.HasOne(d => d.User).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_id_");
        });

        modelBuilder.Entity<TblOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__tbl_Orde__3C5A4080CA70C6CA");

            entity.ToTable("tbl_Order_Detail");

            entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");
            entity.Property(e => e.BookDetailId).HasColumnName("book_Detail_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.BookDetail).WithMany(p => p.TblOrderDetails)
                .HasForeignKey(d => d.BookDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orderDetail_Book_Detail_id");

            entity.HasOne(d => d.Order).WithMany(p => p.TblOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orderDetail_id");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tbl_User__EE50E8ED2B0567BF");

            entity.ToTable("tbl_User");

            entity.Property(e => e.UserId).HasColumnName("user_id_");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_");
            entity.Property(e => e.ProfileImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profile_image_url");
            entity.Property(e => e.Role).HasColumnName("role_");
            entity.Property(e => e.UserAddress)
                .HasMaxLength(255)
                .HasColumnName("user_address");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name_");
        });

        modelBuilder.Entity<TblUserWishlist>(entity =>
        {
            entity.HasKey(e => e.WishlistId).HasName("PK__tbl_User__6151514EC2292E1A");

            entity.ToTable("tbl_User_wishlist");

            entity.Property(e => e.WishlistId).HasColumnName("wishlist_id");
            entity.Property(e => e.BookDetailId).HasColumnName("book_Detail_id");
            entity.Property(e => e.UserId).HasColumnName("user_id_");

            entity.HasOne(d => d.BookDetail).WithMany(p => p.TblUserWishlists)
                .HasForeignKey(d => d.BookDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_wishlist_Book_Detail");

            entity.HasOne(d => d.User).WithMany(p => p.TblUserWishlists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_wishlist_user_id");
        });

        modelBuilder.Entity<UserWishlist>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("UserWishlist");

            entity.Property(e => e.BookDetailId).HasColumnName("Book_Detail_id");
            entity.Property(e => e.BookImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("book_image_url");
            entity.Property(e => e.BookTitle)
                .HasMaxLength(255)
                .HasColumnName("book_title");
            entity.Property(e => e.FormatName)
                .HasMaxLength(50)
                .HasColumnName("format_name");
            entity.Property(e => e.UserId).HasColumnName("user_id_");
        });

        modelBuilder.Entity<ViewAuthorDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewAuthorDetail");

            entity.Property(e => e.AuthorDescription).HasColumnName("author_description_");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(255)
                .HasColumnName("author_name");
            entity.Property(e => e.ProfileImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profile_image_url");
            entity.Property(e => e.PublishedBooks).HasColumnName("published_books");
        });

        modelBuilder.Entity<ViewBlogDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewBlogDetail");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(255)
                .HasColumnName("author_name");
            entity.Property(e => e.BlogContent).HasColumnName("blog_content");
            entity.Property(e => e.BlogDescription)
                .HasMaxLength(255)
                .HasColumnName("blog_description_");
            entity.Property(e => e.BlogId).HasColumnName("blog_id");
            entity.Property(e => e.BlogTitle)
                .HasMaxLength(255)
                .HasColumnName("blog_title");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("img_url");
            entity.Property(e => e.Views).HasColumnName("views_");
        });

        modelBuilder.Entity<ViewBookAlert>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewBookAlert");

            entity.Property(e => e.AuthorName)
                .HasMaxLength(255)
                .HasColumnName("author_name");
            entity.Property(e => e.BookDetailId).HasColumnName("book_Detail_id");
            entity.Property(e => e.BookImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("book_image_url");
            entity.Property(e => e.BookTitle)
                .HasMaxLength(255)
                .HasColumnName("book_title");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.ImgHomeBanner)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("img_home_banner");
            entity.Property(e => e.ImgProductsBanner)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("img_products_banner");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<ViewBookDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewBookDetails");

            entity.Property(e => e.AuthorDescription).HasColumnName("author_description_");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(255)
                .HasColumnName("author_name");
            entity.Property(e => e.BookDescription).HasColumnName("book_description_");
            entity.Property(e => e.BookDetailId).HasColumnName("book_Detail_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.BookImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("book_image_url");
            entity.Property(e => e.BookTitle)
                .HasMaxLength(255)
                .HasColumnName("book_title");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("category_name");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.FormatId).HasColumnName("format_id");
            entity.Property(e => e.FormatName)
                .HasMaxLength(50)
                .HasColumnName("format_name");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.GenreName)
                .HasMaxLength(50)
                .HasColumnName("genre_name");
            entity.Property(e => e.IllustrationsNote)
                .HasMaxLength(255)
                .HasColumnName("Illustrations_note");
            entity.Property(e => e.Isbn10)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISBN10");
            entity.Property(e => e.Isbn13)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISBN13");
            entity.Property(e => e.Language)
                .HasMaxLength(30)
                .HasColumnName("language_");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProfileImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profile_image_url");
            entity.Property(e => e.Publisher).HasMaxLength(255);
            entity.Property(e => e.StockQuantity).HasColumnName("stock_quantity");
            entity.Property(e => e.Views).HasColumnName("views_");
        });

        modelBuilder.Entity<ViewNewReleaseBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewNewReleaseBooks");

            entity.Property(e => e.AuthorName)
                .HasMaxLength(255)
                .HasColumnName("author_name");
            entity.Property(e => e.BookDescription).HasColumnName("book_description_");
            entity.Property(e => e.BookDetailId).HasColumnName("book_Detail_id");
            entity.Property(e => e.BookImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("book_image_url");
            entity.Property(e => e.BookTitle)
                .HasMaxLength(255)
                .HasColumnName("book_title");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("category_name");
            entity.Property(e => e.FormatName)
                .HasMaxLength(50)
                .HasColumnName("format_name");
            entity.Property(e => e.GenreName)
                .HasMaxLength(50)
                .HasColumnName("genre_name");
        });

        modelBuilder.Entity<ViewOrderDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewOrderDetails");

            entity.Property(e => e.BookDetailId).HasColumnName("Book_Detail_id");
            entity.Property(e => e.BookImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("book_image_url");
            entity.Property(e => e.BookTitle)
                .HasMaxLength(255)
                .HasColumnName("book_title");
            entity.Property(e => e.FormatName)
                .HasMaxLength(50)
                .HasColumnName("format_name");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(255)
                .HasColumnName("shipping_address");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id_");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name_");
        });

        modelBuilder.Entity<ViewTop20BestSellingBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewTop20BestSellingBooks");

            entity.Property(e => e.AuthorDescription).HasColumnName("author_description_");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(255)
                .HasColumnName("author_name");
            entity.Property(e => e.BookDescription).HasColumnName("book_description_");
            entity.Property(e => e.BookDetailId).HasColumnName("book_Detail_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.BookImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("book_image_url");
            entity.Property(e => e.BookTitle)
                .HasMaxLength(255)
                .HasColumnName("book_title");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("category_name");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.FormatId).HasColumnName("format_id");
            entity.Property(e => e.FormatName)
                .HasMaxLength(50)
                .HasColumnName("format_name");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.GenreName)
                .HasMaxLength(50)
                .HasColumnName("genre_name");
            entity.Property(e => e.IllustrationsNote)
                .HasMaxLength(255)
                .HasColumnName("Illustrations_note");
            entity.Property(e => e.Isbn10)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISBN10");
            entity.Property(e => e.Isbn13)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISBN13");
            entity.Property(e => e.Language)
                .HasMaxLength(30)
                .HasColumnName("language_");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProfileImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profile_image_url");
            entity.Property(e => e.Publisher).HasMaxLength(255);
            entity.Property(e => e.StockQuantity).HasColumnName("stock_quantity");
            entity.Property(e => e.TotalQuantitySold).HasColumnName("total_quantity_sold");
            entity.Property(e => e.Views).HasColumnName("views_");
        });

        modelBuilder.Entity<ViewTopBloger>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewTopBloger");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(255)
                .HasColumnName("author_name");
            entity.Property(e => e.NumBlogs).HasColumnName("num_blogs");
            entity.Property(e => e.ProfileImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profile_image_url");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
