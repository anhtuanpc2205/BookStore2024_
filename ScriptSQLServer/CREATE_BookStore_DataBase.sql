IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'BookStore')
BEGIN
	CREATE DATABASE BookStore;
END;
GO
USE BookStore;
GO

-- Bảng lưu thông tin về các tác giả
CREATE TABLE tbl_Author(
    author_id INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính: ID của tác giả
    author_name NVARCHAR(255) NOT NULL, -- Tên của tác giả
    author_description_ NVARCHAR(MAX), -- Mô tả về tác giả
	profile_image_url VARCHAR(255) -- Đường dẫn ảnh tác giả
);

-- Tạo bảng Blog
CREATE TABLE tbl_Blog(
    blog_id INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính: ID của bài viết trong blog
    blog_title NVARCHAR(255) NOT NULL, -- Tiêu đề của bài viết trong blog
    blog_description_ NVARCHAR(255), -- Mô tả về bài viết trong blog
    content_ NVARCHAR(MAX), -- Nội dung của bài viết trong blog
    author_id INT NOT NULL, -- Khóa ngoại: ID của tác giả
	img_url VARCHAR(255),
	views_ INT DEFAULT 0
);

-- Bảng lưu thông tin về các hạng mục sách
CREATE TABLE tbl_Category(
    category_id INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính: ID của category
    category_name NVARCHAR(50) NOT NULL -- Tên của category
);

-- Bảng lưu thông tin về các thể loại sách
CREATE TABLE tbl_Genre(
    genre_id INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính: ID của thể loại sách
    genre_name NVARCHAR(50) NOT NULL, -- Tên của thể loại sách
);
-- Bảng lưu thông tin chung về cuốn sách
CREATE TABLE tbl_Book(
    book_id INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính: ID của cuốn sách
    book_title NVARCHAR(255) NOT NULL, -- Tiêu đề của cuốn sách
    author_id INT NOT NULL, -- Khóa ngoại: ID của tác giả
	book_image_url VARCHAR(255), -- Đường dẫn ảnh bìa của cuốn sách
	book_description_ NVARCHAR(MAX), -- Mô tả về cuốn sách
	Publisher NVARCHAR(255), --Nhà xuất bản
	language_ NVARCHAR(30),
	Illustrations_note NVARCHAR(255), --Ghi chú minh họa
	Pages int,
	genre_id INT NOT NULL,
	category_id INT NOT NULL
);

--Bảng lưu thông tin của định dạng sách
CREATE TABLE tbl_Format(
    format_id INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính: ID của định dạng
    format_name NVARCHAR(50) NOT NULL -- Tên của định dạng
);

-- Bảng lưu thông tin chi tiết về cuốn sách 1-n với Book
CREATE TABLE tbl_Book_Detail (
	book_Detail_id INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính: ID của chi tiết cuốn sách
    book_id INT NOT NULL, -- Khóa ngoại: ID của cuốn sách, tham chiếu từ bảng Book
	ISBN10 CHAR(10),
	ISBN13 CHAR(13),
	format_id INT NOT NULL, --Khóa ngoại: ID của 1 định dạng
    stock_quantity INT NOT NULL, -- Số lượng trong kho của cuốn sách
	views_ INT DEFAULT 0, -- Số lượt xem, mặc định là 0
	price DECIMAL(10, 2) NOT NULL, -- Giá của cuốn sách
	discount DECIMAL(5, 2) DEFAULT 0, -- Giảm giá, mặc định là 0
);

-- Bảng lưu thông tin về người dùng
CREATE TABLE tbl_User(
    user_id_ INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính: ID của người dùng
    user_name_ NVARCHAR(50) NOT NULL, -- Tên đăng nhập của người dùng
    email VARCHAR(100) NOT NULL, -- Địa chỉ email của người dùng
    password_ VARCHAR(20) NOT NULL, -- Mật khẩu của người dùng
    shipping_address NVARCHAR(255), -- Địa chỉ giao hàng của người dùng
    role_ TinyInt NOT NULL, -- Vai trò của người dùng (admin, user, ...) 1 cho admin,2 cho khách hàng
    profile_image_url VARCHAR(255) -- Đường dẫn ảnh đại diện của người dùng
);

-- Bảng lưu thông tin về các đơn hàng
CREATE TABLE tbl_Order(
    order_id INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính: ID của đơn hàng
    user_id_ INT NOT NULL, -- Khóa ngoại: ID của người dùng
    order_date DATE NOT NULL, -- Ngày đặt hàng
    total_amount DECIMAL(10, 2) NOT NULL, -- Tổng số tiền của đơn hàng
    order_status VARCHAR(20) NOT NULL, -- Trạng thái của đơn hàng
    shipping_method NVARCHAR(100), -- Phương thức vận chuyển
    payment_method TinyInt NOT NULL, -- Phương thức thanh toán
    shipping_fee DECIMAL(10, 2) -- Phí vận chuyển
);

-- Bảng lưu thông tin về các chi tiết đơn hàng 1-n
CREATE TABLE tbl_Order_Detail(
	order_detail_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT NOT NULL, -- Khóa ngoại: ID của đơn hàng
    book_Detail_id INT NOT NULL, -- Khóa ngoại: ID của chi tiết cuốn sách
    quantity INT NOT NULL, -- Số lượng của cuốn sách trong đơn hàng
);

-- Bảng lưu thông tin về user_wishlist 1-n
CREATE TABLE tbl_User_wishlist(
    wishlist_id INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính: ID của wishlist
    user_id_ INT NOT NULL, -- Khóa ngoại: ID của người dùng
    book_Detail_id INT NOT NULL, -- Khóa ngoại: ID của chi tiết cuốn sách
);

-- bảng này lưu thông tin book alert
CREATE TABLE tbl_book_alert( 
	alert_id INT IDENTITY(1,1) PRIMARY KEY,
    book_Detail_id INT,
    img_products_banner VARCHAR(255),
    img_home_banner VARCHAR(255)
);
GO

CREATE TABLE tbl_new_release_books(
    new_release_id INT IDENTITY(1,1) PRIMARY KEY,
    book_Detail_id INT
);
GO
---------------------------------------------------------------------------------------------------------------------------------------------
--INSERT BEGIN
---Category
INSERT INTO tbl_Category(category_name) VALUES 
('Art & Photography'),
('Biography'),
('Children''s Book'),
('Craft & Hobbies'),
('Crime & Thriller'),
('Fantasy & Horror'),
('Fiction'),
('Food & Drink'),
('Graphic,Anime & Manga'),
('Science Fiction');
---Genre
INSERT INTO tbl_Genre(genre_name) VALUES 
('History'),
('Architecture'),
('Art Form');
---User
INSERT INTO tbl_User(user_name_, email, password_, shipping_address, role_, profile_image_url)
VALUES (N'Trần Ngọc Anh Tuấn', 'ngocanhtuan2205@gmail.com', '123', N'32 Hải Thượng Lãn Ông, Tp Vinh', 1, '../images/users/img-01.jpg'),
(N'Nguyễn Văn Hoàng ', 'abc@gmail.com', '123', N'32 Hải Thượng Lãn Ông, Tp Vinh', 2, '../images/users/img-01.jpg'),
(N'Con Mèo Lem Nhem', 'ng2205@gmail.com', '123', N'32 Hải Thượng Lãn Ông, Tp Vinh', 3, '../images/users/img-01.jpg');
---Author
INSERT INTO tbl_Author(author_name, author_description_, profile_image_url) VALUES 
('John Smith', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', '../images/author/imag-01.jpg'),
('Emily Johnson', 'Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam.', '../images/author/imag-02.jpg'),
('Michael Brown', 'At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores.', '../images/author/imag-03.jpg'),
('Sarah Williams', 'Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', '../images/author/imag-04.jpg'),
('David Jones', 'Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.', '../images/author/imag-05.jpg'),
('Jessica Taylor', 'Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.', '../images/author/imag-06.jpg'),
('Christopher Lee', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', '../images/author/imag-07.jpg'),
('Olivia Martin', 'Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur?', '../images/author/imag-08.jpg'),
('Matthew Wilson', 'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.', '../images/author/imag-09.jpg'),
('Sophia Clark', 'Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam.', '../images/author/imag-10.jpg'),
('Ethan Moore', 'Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', '../images/author/imag-11.jpg'),
('Isabella White', 'Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.', '../images/author/imag-12.jpg'),
('Alexander Hall', 'Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.', '../images/author/imag-13.jpg'),
('Ava Thompson', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', '../images/author/imag-14.jpg'),
('William Davis', 'Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur?', '../images/author/imag-15.jpg'),
('Mia Rodriguez', 'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.', '../images/author/imag-16.jpg'),
('James Martinez', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', '../images/author/imag-17.jpg'),
('Emma Anderson', 'Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur?', '../images/author/imag-18.jpg'),
('Benjamin Garcia', 'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.', '../images/author/imag-19.jpg'),
('Charlotte Hernandez', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', '../images/author/imag-20.jpg'),
('Jacob Lopez', 'Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur?', '../images/author/imag-21.jpg'),
('Amelia Nelson', 'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.', '../images/author/imag-22.jpg'),
('Daniel King', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', '../images/author/imag-23.jpg'),
('Harper Carter', 'Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur?', '../images/author/imag-24.jpg'),
('Scarlet Hawthorne', 'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.', '../images/author/imag-25.jpg'),
('Evelyn Ramirez', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', '../images/author/imag-26.jpg');
---Format_
INSERT INTO tbl_Format(format_name) VALUES 
('Hardback'),
('CD-Audio'),
('Paperback'),
('E-Book');
---Blog
INSERT INTO tbl_Blog (blog_title, blog_description_, content_, author_id, img_url, views_)
VALUES (
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    1, -- ID của tác giả
    '../images/blog/img-01.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
),
(
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    2, -- ID của tác giả
    '../images/blog/img-02.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
),
(
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    3, -- ID của tác giả
    '../images/blog/img-03.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
),
(
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    4, -- ID của tác giả
    '../images/blog/img-04.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
),
(
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    5, -- ID của tác giả
    '../images/blog/img-05.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
),
(
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    6, -- ID của tác giả
    '../images/blog/img-06.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
),
(
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    7, -- ID của tác giả
    '../images/blog/img-07.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
),
(
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    8, -- ID của tác giả
    '../images/blog/img-08.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
),
(
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    9, -- ID của tác giả
    '../images/blog/img-09.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
),
(
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    10, -- ID của tác giả
    '../images/blog/img-10.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
),
(
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    11, -- ID của tác giả
    '../images/blog/img-11.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
),
(
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    12, -- ID của tác giả
    '../images/blog/img-12.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
),
(
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    13, -- ID của tác giả
    '../images/blog/img-13.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
),
(
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    14, -- ID của tác giả
    '../images/blog/img-14.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
),
(
    'Where The Wild Things Are',
    'Adventure, Fun',
    'Consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim id est laborum sed ut perspiciatis unde omnis iste natus.

Eor sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae vitae dicta sunt explicabo nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aute fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

Labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip apeicommodo consequat aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur excepteur sint occaecat cupidatat non proident, sunt in culpa quistan officia deserunt mollit anim.

Laborum sed ut perspiciatis unde omnis iste natus sit voluptatem accusantium doloremque laudantium totam rem aperiam eaque ipsa quae ab illo inventore veritatis etation quasi architecto beatae.',
    15, -- ID của tác giả
    '../images/blog/img-15.jpg', -- Đường dẫn đến hình ảnh
    DEFAULT -- Giá trị mặc định cho views_
);
---Book
INSERT INTO tbl_Book (book_title, author_id, book_image_url, book_description_, Publisher, language_, Illustrations_note, Pages, genre_id, category_id)
VALUES (
    'Where The Wild Things Are', -- Tiêu đề của sách
    1, -- ID của tác giả
    '../images/books/img-01.jpg', -- Đường dẫn đến ảnh bìa của sách
    'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', -- Mô tả về sách
    'Sunshine Orlando', -- Nhà xuất bản
    'English', -- Ngôn ngữ
    'b&w images thru-out; 1 x 16pp colour plates', -- Ghi chú về minh họa
    120, -- Số trang
    1, -- ID của thể loại
    1 -- ID của hạng mục
),
(
	 'Educated: A Memoir', -- Tiêu đề của sách
    1, -- ID của tác giả
    '../images/books/img-02.jpg', -- Đường dẫn đến ảnh bìa của sách
    N'"Educated" là một cuốn hồi ký của Tara Westover, kể về cuộc sống của cô trong một gia đình mormon cực kỳ cứng rắn ở Idaho. Tara không được học hành chính thống, nhưng thông qua sự tự học và nỗ lực không ngừng, cô đã tự mình học được và sau đó tốt nghiệp đại học và cao học tại Đại học Harvard và Đại học Cambridge. Cuốn sách tường thuật về hành trình vượt qua nghịch cảnh và tìm kiếm sự giáo dục và tự do cá nhân của Tara.', -- Mô tả về sách
    'Sunshine Orlando', -- Nhà xuất bản
    'English', -- Ngôn ngữ
    'b&w images thru-out; 1 x 16pp colour plates', -- Ghi chú về minh họa
	352, -- Số trang
    2, -- ID của thể loại
    1 -- ID của hạng mục
),
(
	 'The Great Gatsby', -- Tiêu đề của sách
    3, -- ID của tác giả
    '../images/books/img-03.jpg', -- Đường dẫn đến ảnh bìa của sách
    N'"The Great Gatsby" là một câu chuyện kinh điển về cuộc sống ở thị trấn West Egg trên Long Island vào những năm 1920. Câu chuyện được kể qua góc nhìn của Nick Carraway, một nhân chứng về cuộc sống xa hoa và những khao khát đen tối của Jay Gatsby.',
    'Scribner', -- Nhà xuất bản
    'English', -- Ngôn ngữ
    'b&w images thru-out; 1 x 16pp colour plates', -- Ghi chú về minh họa
	180, -- Số trang
    2, -- ID của thể loại
    1 -- ID của hạng mục
),
(
	 'To Kill a Mockingbird', -- Tiêu đề của sách
    4, -- ID của tác giả
    '../images/books/img-04.jpg', -- Đường dẫn đến ảnh bìa của sách
    N'"To Kill a Mockingbird" là một tiểu thuyết kinh điển về sự phân biệt chủng tộc và sự nghèo đói ở Nam Hoa Kỳ trong những năm 1930. Câu chuyện được kể qua góc nhìn của Scout Finch, một cô bé ở thị trấn nhỏ Maycomb, Alabama, khi bố cô làm luật sư để bảo vệ một người đàn ông da đen bị cáo buộc giao cấu với một phụ nữ da trắng.',
    'J.B. Lippincott & Co.', -- Nhà xuất bản
    'English', -- Ngôn ngữ
    'b&w images thru-out; 1 x 16pp colour plates', -- Ghi chú về minh họa
	324, -- Số trang
    3, -- ID của thể loại
    7 -- ID của hạng mục
),
(
	 'Pride and Prejudice', -- Tiêu đề của sách
    5, -- ID của tác giả
    '../images/books/img-05.jpg', -- Đường dẫn đến ảnh bìa của sách
    N'"Pride and Prejudice" là một tiểu thuyết lãng mạn về tình yêu, gia đình và xã hội ở thế kỷ 19 ở Anh. Câu chuyện xoay quanh cuộc sống của Elizabeth Bennet, một cô gái thông minh và nhanh nhạy, khi cô đấu tranh với lòng tự trọng và sự định kiến xã hội.',
    'T. Egerton, Whitehall', -- Nhà xuất bản
    'English', -- Ngôn ngữ
    'b&w images thru-out; 1 x 16pp colour plates', -- Ghi chú về minh họa
	279, -- Số trang
    2, -- ID của thể loại
    5 -- ID của hạng mục
),
(
	 'Harry Potter and the Sorcerer''s Stone', -- Tiêu đề của sách
    5, -- ID của tác giả
    '../images/books/img-06.jpg', -- Đường dẫn đến ảnh bìa của sách
    N'"Pride and Prejudice" là một tiểu thuyết lãng mạn về tình yêu, gia đình và xã hội ở thế kỷ 19 ở Anh. Câu chuyện xoay quanh cuộc sống của Elizabeth Bennet, một cô gái thông minh và nhanh nhạy, khi cô đấu tranh với lòng tự trọng và sự định kiến xã hội.',
    ' Scholastic', -- Nhà xuất bản
    'English', -- Ngôn ngữ
    'b&w images thru-out; 1 x 16pp colour plates', -- Ghi chú về minh họa
	309, -- Số trang
    1, -- ID của thể loại
    4 -- ID của hạng mục
),
(
	 'The Catcher in the Rye', -- Tiêu đề của sách
    7, -- ID của tác giả
    '../images/books/img-07.jpg', -- Đường dẫn đến ảnh bìa của sách
    N'"The Catcher in the Rye" là một tiểu thuyết về tuổi trẻ và sự mất mát của ngây thơ. Câu chuyện được kể qua góc nhìn của Holden Caulfield, một thiếu niên cảm thấy loài người xung quanh đều giả dối và thiếu chân thành.',
    'Little, Brown and Company', -- Nhà xuất bản
    'English', -- Ngôn ngữ
    'b&w images thru-out; 1 x 16pp colour plates', -- Ghi chú về minh họa
	277, -- Số trang
    3, -- ID của thể loại
    6 -- ID của hạng mục
),
(
	 'The Catcher in the Rye', -- Tiêu đề của sách
    7, -- ID của tác giả
    '../images/books/img-08.jpg', -- Đường dẫn đến ảnh bìa của sách
    N'"The Catcher in the Rye" là một tiểu thuyết về tuổi trẻ và sự mất mát của ngây thơ. Câu chuyện được kể qua góc nhìn của Holden Caulfield, một thiếu niên cảm thấy loài người xung quanh đều giả dối và thiếu chân thành.',
    'Little, Brown and Company', -- Nhà xuất bản
    'English', -- Ngôn ngữ
    'b&w images thru-out; 1 x 16pp colour plates', -- Ghi chú về minh họa
	277, -- Số trang
    3, -- ID của thể loại
    6 -- ID của hạng mục
),
(
	 'The Lord of the Rings', -- Tiêu đề của sách
    8, -- ID của tác giả
    '../images/books/img-09.jpg', -- Đường dẫn đến ảnh bìa của sách
    N'"The Lord of the Rings" là một cuộc phiêu lưu kỳ diệu trải dài qua thế giới Middle-earth, xoay quanh chiến đấu giữa tốt và ác, sự tiêu diệt và hy vọng. Câu chuyện bắt đầu khi Frodo Baggins, một người hobbit, nhận được nhiệm vụ tiêu diệt chiếc nhẫn của Sauron.',
    'Allen & Unwin', -- Nhà xuất bản
    'English', -- Ngôn ngữ
    'b&w images thru-out; 1 x 16pp colour plates', -- Ghi chú về minh họa
	1178, -- Số trang
    1, -- ID của thể loại
    3 -- ID của hạng mục
),
(
	 'Animal Farm', -- Tiêu đề của sách
    10, -- ID của tác giả
    '../images/books/img-10.jpg', -- Đường dẫn đến ảnh bìa của sách
    N'"Animal Farm" là một tiểu thuyết truyền cảm hứng về sự cải cách xã hội và quyền lực. Câu chuyện diễn ra tại một trang trại nông nghiệp, nơi các loài động vật lập ra một xã hội đa đảng và chống lại sự thống trị của con người.',
    'Secker and Warburg', -- Nhà xuất bản
    'English', -- Ngôn ngữ
    'b&w images thru-out; 1 x 16pp colour plates', -- Ghi chú về minh họa
	112, -- Số trang
    2, -- ID của thể loại
    6 -- ID của hạng mục
),
(
	 'The Alchemist', -- Tiêu đề của sách
    10, -- ID của tác giả
    '../images/books/img-11.jpg', -- Đường dẫn đến ảnh bìa của sách
    N'"The Alchemist" là một tiểu thuyết triết học về tình yêu, sự hiểu biết và cuộc sống. Câu chuyện theo chân Santiago, một chăn cừu ở Tây Ban Nha, trong cuộc hành trình đi tìm kiếm ngọc lục bảo và ý nghĩa thực sự của cuộc sống.',
    'HarperCollins', -- Nhà xuất bản
    'English', -- Ngôn ngữ
    'b&w images thru-out; 1 x 16pp colour plates', -- Ghi chú về minh họa
	197, -- Số trang
    2, -- ID của thể loại
    6 -- ID của hạng mục
),
(
	 'The Chronicles of Narnia: The Lion, the Witch and the Wardrobe', -- Tiêu đề của sách
    12, -- ID của tác giả
    '../images/books/img-12.jpg', -- Đường dẫn đến ảnh bìa của sách
    N'"The Chronicles of Narnia: The Lion, the Witch and the Wardrobe" là một cuốn sách truyền kỳ về cuộc phiêu lưu của bốn đứa trẻ trong thế giới ma thuật của Narnia. Cuốn sách khám phá chủ đề về lòng dũng cảm, lòng tin và sự kiên nhẫn.',
    'Geoffrey Bles', -- Nhà xuất bản
    'English', -- Ngôn ngữ
    'b&w images thru-out; 1 x 16pp colour plates', -- Ghi chú về minh họa
	206, -- Số trang
    1, -- ID của thể loại
    9 -- ID của hạng mục
);
---BookDetail
INSERT INTO tbl_Book_Detail (book_id, ISBN10, ISBN13, format_id, stock_quantity, price)
VALUES 
(
    1, -- ID của cuốn sách Where The Wild Things Are
    '0064431789', -- ISBN10
    '9780064431781', -- ISBN13
    1, -- ID của định dạng
    50, -- Số lượng trong kho của cuốn sách
    12.99 -- Giá của cuốn sách
),
(
    1, -- ID của cuốn sách Where The Wild Things Are
    '0064431789', -- ISBN10
    '9780064431781', -- ISBN13
    2, -- ID của định dạng
    30, -- Số lượng trong kho của cuốn sách
    9.99 -- Giá của cuốn sách
),
(
    2, -- ID của cuốn sách Educated: A Memoir
    '0399590501', -- ISBN10
    '9780399590504', -- ISBN13
    1, -- ID của định dạng
    20, -- Số lượng trong kho của cuốn sách
    15.99 -- Giá của cuốn sách
),
(
    2, -- ID của cuốn sách Educated: A Memoir
    '0399590501', -- ISBN10
    '9780399590504', -- ISBN13
    2, -- ID của định dạng
    15, -- Số lượng trong kho của cuốn sách
    12.99 -- Giá của cuốn sách
),
(
    3, -- ID của cuốn sách The Great Gatsby
    '0743273567', -- ISBN10
    '9780743273565', -- ISBN13
    1, -- ID của định dạng
    40, -- Số lượng trong kho của cuốn sách
    10.99 -- Giá của cuốn sách
),
(
    3, -- ID của cuốn sách The Great Gatsby
    '0743273567', -- ISBN10
    '9780743273565', -- ISBN13
    2, -- ID của định dạng
    25, -- Số lượng trong kho của cuốn sách
    8.99 -- Giá của cuốn sách
),
(
    4, -- ID của cuốn sách To Kill a Mockingbird
    '0061120081', -- ISBN10
    '9780061120084', -- ISBN13
    1, -- ID của định dạng
    35, -- Số lượng trong kho của cuốn sách
    11.99 -- Giá của cuốn sách
),
(
    4, -- ID của cuốn sách To Kill a Mockingbird
    '0061120081', -- ISBN10
    '9780061120084', -- ISBN13
    2, -- ID của định dạng
    28, -- Số lượng trong kho của cuốn sách
    9.99 -- Giá của cuốn sách
),
(
    5, -- ID của cuốn sách Pride and Prejudice
    '0141439513', -- ISBN10
    '9780141439518', -- ISBN13
    1, -- ID của định dạng
    60, -- Số lượng trong kho của cuốn sách
    8.99 -- Giá của cuốn sách
),
(
    5, -- ID của cuốn sách Pride and Prejudice
    '0141439513', -- ISBN10
    '9780141439518', -- ISBN13
    2, -- ID của định dạng
    45, -- Số lượng trong kho của cuốn sách
    6.99 -- Giá của cuốn sách
),
(
    6, -- ID của cuốn sách
    '1234567890', -- ISBN10
    '1234567890123', -- ISBN13
    1, -- ID của định dạng sách
    100, -- Số lượng trong kho
    25.99 -- Giá
),
(
    6, -- ID của cuốn sách
    '0987654321', -- ISBN10
    '0987654321098', -- ISBN13
    2, -- ID của định dạng sách
    50, -- Số lượng trong kho
    19.99 -- Giá
),
(
    7, -- ID của cuốn sách
    '2345678901', -- ISBN10
    '2345678901234', -- ISBN13
    1, -- ID của định dạng sách
    80, -- Số lượng trong kho
    21.99 -- Giá
),
(
    7, -- ID của cuốn sách
    '3456789012', -- ISBN10
    '3456789012345', -- ISBN13
    3, -- ID của định dạng sách
    60, -- Số lượng trong kho
    29.99 -- Giá
),
(
    8, -- ID của cuốn sách
    '4567890123', -- ISBN10
    '4567890123456', -- ISBN13
    2, -- ID của định dạng sách
    70, -- Số lượng trong kho
    24.99 -- Giá
),
(
    8, -- ID của cuốn sách
    '5678901234', -- ISBN10
    '5678901234567', -- ISBN13
    1, -- ID của định dạng sách
    40, -- Số lượng trong kho
    18.99 -- Giá
),
(
    9, -- ID của cuốn sách
    '6789012345', -- ISBN10
    '6789012345678', -- ISBN13
    1, -- ID của định dạng sách
    90, -- Số lượng trong kho
    26.99 -- Giá
),
(
    9, -- ID của cuốn sách
    '7890123456', -- ISBN10
    '7890123456789', -- ISBN13
    2, -- ID của định dạng sách
    55, -- Số lượng trong kho
    20.99 -- Giá
),
(
    10, -- ID của cuốn sách
    '8901234567', -- ISBN10
    '8901234567890', -- ISBN13
    3, -- ID của định dạng sách
    75, -- Số lượng trong kho
    28.99 -- Giá
),
(
    10, -- ID của cuốn sách
    '9012345678', -- ISBN10
    '9012345678901', -- ISBN13
    1, -- ID của định dạng sách
    65, -- Số lượng trong kho
    22.99 -- Giá
),
(
    11, -- ID của cuốn sách The Alchemist
    '0061122416', -- ISBN10
    '9780061122415', -- ISBN13
    1, -- ID của định dạng
    25, -- Số lượng trong kho của cuốn sách
    9.99 -- Giá của cuốn sách
),
(
    11, -- ID của cuốn sách The Alchemist
    '0061122416', -- ISBN10
    '9780061122415', -- ISBN13
    2, -- ID của định dạng
    20, -- Số lượng trong kho của cuốn sách
    7.99 -- Giá của cuốn sách
),
(
    11, -- ID của cuốn sách The Alchemist
    '0061122416', -- ISBN10
    '9780061122415', -- ISBN13
    3, -- ID của định dạng
    15, -- Số lượng trong kho của cuốn sách
    5.99 -- Giá của cuốn sách
),
(
    12, -- ID của cuốn sách The Chronicles of Narnia: The Lion, the Witch and the Wardrobe
    '0061122416', -- ISBN10
    '9780061122415', -- ISBN13
    1, -- ID của định dạng
    30, -- Số lượng trong kho của cuốn sách
    11.99 -- Giá của cuốn sách
),
(
    12, -- ID của cuốn sách The Chronicles of Narnia: The Lion, the Witch and the Wardrobe
    '0061122416', -- ISBN10
    '9780061122415', -- ISBN13
    2, -- ID của định dạng
    25, -- Số lượng trong kho của cuốn sách
    8.99 -- Giá của cuốn sách
),
(
    12, -- ID của cuốn sách The Chronicles of Narnia: The Lion, the Witch and the Wardrobe
    '0061122416', -- ISBN10
    '9780061122415', -- ISBN13
    3, -- ID của định dạng
    20, -- Số lượng trong kho của cuốn sách
    6.99 -- Giá của cuốn sách
);

---insert các order
INSERT INTO tbl_Order (user_id_, order_date, total_amount, order_status, shipping_method, payment_method, shipping_fee)
VALUES (1, '2024-03-27', 100.00, N'Đang xử lý', N'Giao hàng tiêu chuẩn', 1, 5.00);

-- Lấy ID của đơn hàng vừa thêm vào
DECLARE @order_id INT;
SET @order_id = SCOPE_IDENTITY();

-- Thêm các mục trong đơn hàng vào tbl_Order_Detail
INSERT INTO tbl_Order_Detail (order_id, book_Detail_id, quantity)
VALUES 
    (@order_id, 1, 2),  -- Đặt 2 cuốn sách có ID là 1 vào đơn hàng
    (@order_id, 3, 1);  -- Đặt 1 cuốn sách có ID là 3 vào đơn hàng

INSERT INTO tbl_Order (user_id_, order_date, total_amount, order_status, shipping_method, payment_method, shipping_fee)
VALUES
(2, '2024-03-28', 150.00, N'Hoàn tất', N'Giao hàng tiêu chuẩn', 1, 5.00),
(2, '2024-03-29', 160.00, N'Hoàn tất', N'Giao hàng tiêu chuẩn', 2, 8.00),
(2, '2024-03-30', 170.00, N'Hoàn tất', N'Giao hàng tiêu chuẩn', 1, 6.00);

-- Đơn hàng 1
INSERT INTO tbl_Order_Detail (order_id, book_Detail_id, quantity)
VALUES
(1, 1, 3),  -- Ví dụ: Mua 3 cuốn sách có book_Detail_id là 1
(1, 2, 3),
(1, 3, 3);

-- Đơn hàng 2
INSERT INTO tbl_Order_Detail (order_id, book_Detail_id, quantity)
VALUES
(2, 4, 3),  -- Ví dụ: Mua 3 cuốn sách có book_Detail_id là 4
(2, 5, 3),
(2, 6, 3);

-- Đơn hàng 3
INSERT INTO tbl_Order_Detail (order_id, book_Detail_id, quantity)
VALUES
(3, 7, 3),  -- Ví dụ: Mua 3 cuốn sách có book_Detail_id là 7
(3, 8, 3),
(3, 9, 3);

-- bảng book_alert
INSERT INTO tbl_book_alert (book_Detail_id, img_products_banner, img_home_banner)
VALUES (1, '../images/banners/img-04.png', '../images/banners/img-02.png');

-- bảng tbl_new_release_books
INSERT INTO tbl_new_release_books (book_Detail_id)
VALUES
(2),
(5),
(18);


UPDATE tbl_Book_Detail
SET discount = price/5
WHERE price >= 15

UPDATE tbl_Book_Detail
SET views_ = 30
WHERE price >= 15

UPDATE tbl_Author SET author_description_ = 'Consectetur adipisicing elit sed do eiusmod tempor incididunt labore toloregna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamcoiars nisiuip commodo consequat aute irure dolor in aprehenderit aveli esseati cillum dolor fugiat nulla pariatur cepteur sint occaecat cupidatat.
Caanon proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnisate natus error sit voluptatem accusantium doloremque totam rem aperiam, eaque ipsa quae abillo inventoe veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia.
Voluptas sit asapernatur aut odit aut fugit, sed quia consequuntur magni dolores eos quistan ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.'
GO

--INSERT END
---------------------------------------------------------------------------------------------------------------------------------------------
--FOREIGN KEY BEGIN
-- Book
ALTER TABLE tbl_Book
ADD CONSTRAINT fk_author_id FOREIGN KEY (author_id) REFERENCES tbl_Author(author_id);
ALTER TABLE tbl_Book
ADD CONSTRAINT fk_category_id FOREIGN KEY (category_id) REFERENCES tbl_Category(category_id);
ALTER TABLE tbl_Book
ADD CONSTRAINT fk_Genre_id FOREIGN KEY (genre_id) REFERENCES tbl_Genre(genre_id);

-- Book_Detail
ALTER TABLE tbl_Book_Detail
ADD CONSTRAINT fk_bookDetail FOREIGN KEY (book_id) REFERENCES tbl_Book(book_id);
ALTER TABLE tbl_Book_Detail
ADD CONSTRAINT fk_bookDetail_Format_ FOREIGN KEY (format_id) REFERENCES tbl_Format(format_id );

-- Order_
ALTER TABLE tbl_Order
ADD CONSTRAINT user_id_ FOREIGN KEY (user_id_) REFERENCES tbl_User(user_id_);

-- Blog
ALTER TABLE tbl_Blog
ADD CONSTRAINT fk_Blog_author_id FOREIGN KEY (author_id) REFERENCES tbl_Author(author_id);

--Order_Detail
ALTER TABLE tbl_Order_Detail
ADD CONSTRAINT fk_orderDetail_id FOREIGN KEY (order_id) REFERENCES tbl_Order(order_id);

ALTER TABLE tbl_Order_Detail
ADD CONSTRAINT fk_orderDetail_Book_Detail_id FOREIGN KEY (Book_Detail_id) REFERENCES tbl_Book_Detail(Book_Detail_id);

--user_wishlist
ALTER TABLE tbl_User_wishlist
ADD CONSTRAINT fk_user_wishlist_user_id FOREIGN KEY (user_id_) REFERENCES tbl_User(user_id_); 
ALTER TABLE tbl_User_wishlist
ADD CONSTRAINT fk_user_wishlist_Book_Detail FOREIGN KEY (Book_Detail_id) REFERENCES tbl_Book_Detail(Book_Detail_id);

--tbl_book_alert
ALTER TABLE tbl_book_alert
ADD CONSTRAINT FK_book_alert FOREIGN KEY (book_Detail_id)
REFERENCES tbl_Book_Detail(book_Detail_id);

--tbl_new_release_books
ALTER TABLE tbl_new_release_books
ADD CONSTRAINT FK_new_release FOREIGN KEY (book_Detail_id)
REFERENCES tbl_Book_Detail(book_Detail_id);
--FOREIGN KEY END
---------------------------------------------------------------------------------------------------------------------------------------------
GO

 --VIEW BEGIN
 ---Thông tin chi tiết của 1 cuốn sách
CREATE VIEW ViewBookDetails
AS
SELECT 
    BD.book_Detail_id,
    B.book_id,
    B.book_title,
    B.author_id,
    A.author_name,
    A.author_description_,
    A.profile_image_url,
    B.book_image_url,
    B.book_description_,
    B.Publisher,
    B.language_,
    B.Illustrations_note,
    B.Pages,
    B.genre_id,
    G.genre_name,
    B.category_id,
    C.category_name,
    BD.ISBN10,
    BD.ISBN13,
    BD.format_id,
    F.format_name,
    BD.stock_quantity,
    BD.views_,
    BD.price,
    BD.discount
FROM tbl_Book B
JOIN tbl_Author A ON B.author_id = A.author_id
JOIN tbl_Book_Detail BD ON B.book_id = BD.book_id
JOIN tbl_Genre G ON B.genre_id = G.genre_id
JOIN tbl_Category C ON B.category_id = C.category_id
JOIN tbl_Format F ON BD.format_id = F.format_id;
GO
---thông tin chi tiết của 1 order
CREATE VIEW ViewOrderDetails AS
SELECT 
    O.order_id,
    O.user_id_,
    O.order_date,
    U.shipping_address,
    O.total_amount,
    OD.order_detail_id,
    OD.Book_Detail_id,
    OD.quantity,
    B.book_title,
    B.book_image_url,
    F.format_name,
    U.user_name_
FROM 
    tbl_order O
JOIN 
    tbl_order_detail OD ON O.order_id = OD.order_id
JOIN 
    tbl_Book_Detail BD ON OD.Book_Detail_id = BD.Book_Detail_id
JOIN 
    tbl_Book B ON BD.book_id = B.book_id
JOIN 
    tbl_format F ON BD.format_id = F.format_id
JOIN 
    tbl_user U ON O.user_id_ = U.user_id_;

GO
---danh sách các cuốn sách mong muốn của 1 user
CREATE VIEW UserWishlist AS
SELECT 
    W.user_id_,
    BD.Book_Detail_id,
    B.book_title,
    B.book_image_url,
    F.format_name
FROM 
    tbl_User_wishlist W
JOIN 
    tbl_Book_Detail BD ON W.Book_Detail_id = BD.Book_Detail_id
JOIN 
    tbl_Book B ON BD.book_id = B.book_id
JOIN 
    tbl_Format F ON BD.format_id = F.format_id;

GO
---thông tin chi tiết của 1 blog-post
CREATE VIEW ViewBlogDetail AS
SELECT 
    B.blog_id,
    B.blog_title AS blog_title,
	B.blog_description_,
    B.content_ AS blog_content,
    B.author_id,
    A.author_name,
	B.img_url,
	B.views_
FROM 
    tbl_blog B
JOIN 
    tbl_author A ON B.author_id = A.author_id;
GO
---View cho biết số lượng blog mà 1 tác giả viết
GO
CREATE VIEW ViewTopBloger AS
SELECT
	A.author_id,
	A.author_name,
	A.profile_image_url,
	COUNT(B.blog_id) AS num_blogs
FROM
	tbl_Author A
LEFT JOIN 
	tbl_Blog B ON A.author_id = B.author_id
GROUP BY 
    A.author_id, A.author_name,A.profile_image_url
ORDER BY num_blogs DESC


GO
---View tìm cuốn sách có số lượng mua lớn nhất
--CREATE VIEW ViewBookAlert AS
--SELECT 
--    VOD.Book_Detail_id,
--    VOD.book_title,
--    VOD.total_quantity_sold,
--    B.book_image_url,
--    A.author_name,
--    BD.price,
--    BD.discount
--FROM (
--    SELECT 
--        Book_Detail_id,
--        book_title,
--        SUM(quantity) AS total_quantity_sold
--    FROM 
--        ViewOrderDetails
--    GROUP BY 
--        Book_Detail_id, book_title
--) AS VOD 
--JOIN tbl_Book_Detail BD ON VOD.Book_Detail_id = BD.Book_Detail_id
--JOIN tbl_Book B ON BD.book_id = B.book_id
--JOIN tbl_Author A ON B.author_id = A.author_id
--WHERE VOD.total_quantity_sold = (
--    SELECT MAX(total_quantity_sold)
--    FROM (
--        SELECT 
--            Book_Detail_id,
--            SUM(quantity) AS total_quantity_sold
--        FROM 
--            ViewOrderDetails
--        GROUP BY 
--            Book_Detail_id
--    ) AS VOD
--);
--GO
--VIEW ViewBookAlert dùng cho banner book alert
CREATE VIEW ViewBookAlert AS
SELECT 
    BA.book_Detail_id,
    book_title,
    B.book_image_url,
    A.author_name,
    BD.price,
    BD.discount,
	BA.img_home_banner,
	BA.img_products_banner
FROM 
	tbl_book_alert BA
JOIN
	tbl_Book_Detail BD ON BA.book_Detail_id = bd.book_Detail_id
JOIN
	tbl_Book B ON B.book_id = BD.book_Detail_id
JOIN
	tbl_Author A ON B.author_id = A.author_id


---View best selling tìm top 20 cuốn sách có lượt mua lớn nhất
GO
CREATE VIEW ViewTop20BestSellingBooks AS

SELECT TOP 20
    BD.book_Detail_id,
    B.book_id,
    B.book_title,
    B.author_id,
    A.author_name,
    A.author_description_,
    A.profile_image_url,
    B.book_image_url,
    B.book_description_,
    B.Publisher,
    B.language_,
    B.Illustrations_note,
    B.Pages,
    B.genre_id,
    G.genre_name,
    B.category_id,
    C.category_name,
    BD.ISBN10,
    BD.ISBN13,
    BD.format_id,
    F.format_name,
    BD.stock_quantity,
    BD.views_,
    BD.price,
    BD.discount,
	ISNULL(SUM(OD.quantity) , 0)AS total_quantity_sold
FROM tbl_Book_Detail BD
LEFT JOIN tbl_Book B ON B.book_id = BD.book_id
LEFT JOIN tbl_Author A ON B.author_id = A.author_id
LEFT JOIN tbl_Genre G ON B.genre_id = G.genre_id
LEFT JOIN tbl_Category C ON B.category_id = C.category_id
LEFT JOIN tbl_Format F ON BD.format_id = F.format_id
LEFT JOIN tbl_Order_Detail OD ON OD.book_Detail_id = BD.book_Detail_id
GROUP BY 
BD.book_Detail_id,
    B.book_id,
    B.book_title,
    B.author_id,
    A.author_name,
    A.author_description_,
    A.profile_image_url,
    B.book_image_url,
    B.book_description_,
    B.Publisher,
    B.language_,
    B.Illustrations_note,
    B.Pages,
    B.genre_id,
    G.genre_name,
    B.category_id,
    C.category_name,
    BD.ISBN10,
    BD.ISBN13,
    BD.format_id,
    F.format_name,
    BD.stock_quantity,
    BD.views_,
    BD.price,
    BD.discount
ORDER BY 
    total_quantity_sold DESC;
GO


--- View NewReleaseBooks xem những cuốn sách trong banner new release
CREATE VIEW ViewNewReleaseBooks
AS
SELECT 
    BD.book_Detail_id,
    B.book_title,
    A.author_name,
    B.book_image_url,
    B.book_description_,
    G.genre_name,
    B.category_id,
    C.category_name,
    F.format_name
FROM tbl_Book B
JOIN tbl_Author A ON B.author_id = A.author_id
JOIN tbl_Book_Detail BD ON B.book_id = BD.book_id
JOIN tbl_Genre G ON B.genre_id = G.genre_id
JOIN tbl_Category C ON B.category_id = C.category_id
JOIN tbl_Format F ON BD.format_id = F.format_id
JOIN tbl_new_release_books NR ON NR.book_Detail_id = BD.book_Detail_id;
GO

--- View AuthorDetail xem chi tiết thông tin của 1 tác giả (có thêm phần đếm số sách đã viết của tác giả đó) 
CREATE VIEW ViewAuthorDetail
AS
SELECT 
	   A.author_id
      ,author_name
      ,author_description_
      ,profile_image_url
	  ,count(book_id) As published_books
  FROM tbl_Author A
  LEFT OUTER JOIN tbl_Book B ON A.author_id = B.author_id
  GROUP BY A.author_id
      ,author_name
      ,author_description_
      ,profile_image_url
GO