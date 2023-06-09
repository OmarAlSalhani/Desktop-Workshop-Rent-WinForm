
CREATE TABLE [dbo].[agle_table](
	[agl_id] [int] NOT NULL,
	[fatora_id] [int] NULL,
	[customer_name] [nvarchar](max) NULL,
	[how_pay] [float] NULL,
	[how_stay] [float] NULL,
	[full_money] [float] NULL,
	[the_pay_date] [nvarchar](max) NULL,
	[ok] [int] NULL,
	[sell_date] [date] NULL,
 CONSTRAINT [PK_agle_table] PRIMARY KEY CLUSTERED 
(
	[agl_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ard_s3r_temp_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ard_s3r_temp_table](
	[name] [nvarchar](350) NULL,
	[qty] [int] NULL,
	[days] [int] NULL,
	[price] [decimal](18, 2) NULL,
	[tax] [decimal](18, 2) NULL,
	[total] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ash3ar_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ash3ar_table](
	[fatora_id] [int] NULL,
	[service_name] [nvarchar](550) NULL,
	[unit] [nvarchar](550) NULL,
	[quantity] [float] NULL,
	[product_price_before_tax] [float] NULL,
	[tax] [float] NULL,
	[product_full_price] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[backup_scheduale_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[backup_scheduale_table](
	[id] [int] NOT NULL,
	[the_time] [nvarchar](max) NULL,
	[the_folder] [nvarchar](max) NULL,
 CONSTRAINT [PK_backup_scheduale_table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[black_box_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[black_box_table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userID] [nvarchar](max) NULL,
	[event_name] [nvarchar](max) NULL,
	[event_date] [date] NULL,
	[event_time] [nvarchar](max) NULL,
	[event_screen] [nvarchar](max) NULL,
 CONSTRAINT [PK_black_box_table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories_table](
	[id] [int] NOT NULL,
	[category_name] [nvarchar](300) NULL,
 CONSTRAINT [PK_categories_table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer_kshf_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer_kshf_table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NULL,
	[statment] [nvarchar](max) NULL,
	[value] [decimal](18, 2) NULL,
	[the_date] [date] NULL,
	[userID] [int] NULL,
 CONSTRAINT [PK_customer_kshf_table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customers_paied_money_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customers_paied_money_table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[agl_id] [int] NULL,
	[fatora_id] [int] NULL,
	[customer_name] [nvarchar](250) NULL,
	[value] [float] NULL,
	[the_date] [date] NULL,
	[userID] [int] NULL,
 CONSTRAINT [PK_customers_paied_money_table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customers_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customers_table](
	[customer_id] [int] NOT NULL,
	[customer_name] [nvarchar](450) NULL,
	[customer_landline] [nvarchar](max) NULL,
	[customer_mobile] [nvarchar](max) NULL,
	[customer_second_mobile] [nvarchar](max) NULL,
	[customer_tax_number] [nvarchar](max) NULL,
	[customer_sgl_number] [nvarchar](max) NULL,
	[building_number] [nvarchar](max) NULL,
	[street] [nvarchar](max) NULL,
	[al7e] [nvarchar](max) NULL,
	[town] [nvarchar](max) NULL,
	[country] [nvarchar](max) NULL,
	[aol_moda] [decimal](18, 2) NULL,
 CONSTRAINT [PK_customers_table] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products_logs_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products_logs_table](
	[service_id] [int] NULL,
	[unit] [nvarchar](max) NULL,
	[qty] [float] NULL,
	[price] [float] NULL,
	[full_price] [float] NULL,
	[move_type] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products_table](
	[id] [int] NOT NULL,
	[product_name] [nvarchar](250) NULL,
	[daily_rent] [decimal](18, 2) NULL,
 CONSTRAINT [PK_products_table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles_table](
	[user_id] [nvarchar](250) NOT NULL,
	[manage_customers] [int] NULL,
	[customers_kshf_7sab] [int] NULL,
	[customers_mdeonee] [int] NULL,
	[customers_paied_money] [int] NULL,
	[open_pos] [int] NULL,
	[sales_report] [int] NULL,
	[manage_products] [int] NULL,
	[manage_categories] [int] NULL,
	[manage_settings] [int] NULL,
	[manage_storages] [int] NULL,
	[storages_operations] [int] NULL,
	[manage_users] [int] NULL,
	[manage_users_roles] [int] NULL,
	[manage_blackbox] [int] NULL,
	[snd_qbd] [int] NULL,
	[snd_srf] [int] NULL,
	[snds_report] [int] NULL,
	[manage_daily_brief] [int] NULL,
	[manage_today_agle] [int] NULL,
 CONSTRAINT [PK_roles_table] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sales_body_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sales_body_table](
	[fatora_id] [int] NULL,
	[product_name] [nvarchar](550) NULL,
	[quantity] [float] NULL,
	[product_price_before_tax] [float] NULL,
	[tax] [float] NULL,
	[product_full_price] [float] NULL,
	[ash3ar_qty] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sales_head_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sales_head_table](
	[fatora_id] [int] NOT NULL,
	[bill_type] [nvarchar](max) NULL,
	[sell_date] [nvarchar](max) NULL,
	[sell_time] [nvarchar](max) NULL,
	[customer_name] [nvarchar](max) NULL,
	[total_amount] [float] NULL,
	[net_amount] [float] NULL,
	[userID] [int] NULL,
	[pay_method] [nvarchar](max) NULL,
	[taxes] [float] NULL,
	[total_before_taxes] [float] NULL,
	[paied_money] [float] NULL,
	[cash] [float] NULL,
	[card] [float] NULL,
	[discount] [float] NULL,
 CONSTRAINT [PK_sell_head_table] PRIMARY KEY CLUSTERED 
(
	[fatora_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[services_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[services_table](
	[id] [int] NOT NULL,
	[main_category_id] [int] NULL,
	[service_name] [nvarchar](450) NULL,
	[price_before_tax] [decimal](18, 2) NULL,
 CONSTRAINT [PK_services_table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[snd_kbd_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[snd_kbd_table](
	[id] [int] NOT NULL,
	[reason] [nvarchar](max) NULL,
	[value] [float] NULL,
	[the_date] [date] NULL,
	[username] [nvarchar](max) NULL,
	[notes] [nvarchar](max) NULL,
	[added_date] [date] NULL,
	[pay_method] [nvarchar](max) NULL,
 CONSTRAINT [PK_snd_kbd_table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[snd_srf_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[snd_srf_table](
	[id] [int] NOT NULL,
	[reason] [nvarchar](max) NULL,
	[value] [float] NULL,
	[the_date] [date] NULL,
	[username] [nvarchar](max) NULL,
	[notes] [nvarchar](max) NULL,
	[added_date] [date] NULL,
	[pay_method] [nvarchar](max) NULL,
 CONSTRAINT [PK_snd_srf_table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[storage_logs_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[storage_logs_table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[storage_event] [nvarchar](max) NULL,
	[the_rsed] [float] NULL,
	[the_date] [date] NULL,
	[the_time] [nvarchar](max) NULL,
	[user_id] [int] NULL,
	[storage_id] [int] NULL,
 CONSTRAINT [PK_storage_logs_table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[storage_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[storage_table](
	[id] [int] NOT NULL,
	[storage_name] [nvarchar](450) NOT NULL,
	[storage_value] [float] NOT NULL,
 CONSTRAINT [PK_storage_table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users_table]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users_table](
	[user_id] [int] NOT NULL,
	[username] [nvarchar](450) NULL,
	[password] [nvarchar](max) NULL,
	[user_image] [image] NULL,
	[storage_id] [int] NULL,
 CONSTRAINT [PK_users_table] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_customers_table]    Script Date: 12/22/2021 12:43:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_customers_table] ON [dbo].[customers_table]
(
	[customer_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_products_table]    Script Date: 12/22/2021 12:43:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_products_table] ON [dbo].[products_table]
(
	[product_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_services_table]    Script Date: 12/22/2021 12:43:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_services_table] ON [dbo].[services_table]
(
	[service_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_storage_table]    Script Date: 12/22/2021 12:43:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_storage_table] ON [dbo].[storage_table]
(
	[storage_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_users_table]    Script Date: 12/22/2021 12:43:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_users_table] ON [dbo].[users_table]
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_manage_customers]  DEFAULT ((0)) FOR [manage_customers]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_customers_kshf_7sab]  DEFAULT ((0)) FOR [customers_kshf_7sab]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_customers_mdeonee]  DEFAULT ((0)) FOR [customers_mdeonee]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_customers_paied_money]  DEFAULT ((0)) FOR [customers_paied_money]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_open_pos]  DEFAULT ((0)) FOR [open_pos]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_sales_report]  DEFAULT ((0)) FOR [sales_report]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_manage_products]  DEFAULT ((0)) FOR [manage_products]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_manage_categories]  DEFAULT ((0)) FOR [manage_categories]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_manage_settings]  DEFAULT ((0)) FOR [manage_settings]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_manage_storages]  DEFAULT ((0)) FOR [manage_storages]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_storages_operations]  DEFAULT ((0)) FOR [storages_operations]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_manage_users]  DEFAULT ((0)) FOR [manage_users]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_manage_users_roles]  DEFAULT ((0)) FOR [manage_users_roles]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_manage_blackbox]  DEFAULT ((0)) FOR [manage_blackbox]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_snd_qbd]  DEFAULT ((0)) FOR [snd_qbd]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_snd_srf]  DEFAULT ((0)) FOR [snd_srf]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_snds_report]  DEFAULT ((0)) FOR [snds_report]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_manage_daily_brief]  DEFAULT ((0)) FOR [manage_daily_brief]
GO
ALTER TABLE [dbo].[roles_table] ADD  CONSTRAINT [DF_roles_table_manage_today_agle]  DEFAULT ((0)) FOR [manage_today_agle]
GO
/****** Object:  StoredProcedure [dbo].[Clean]    Script Date: 12/22/2021 12:43:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Clean] as
delete from agle_table
delete from black_box_table
delete from categories_table
delete from customer_kshf_table
delete from customers_paied_money_table
delete from customers_table
delete from products_logs_table
delete from roles_table
delete from sales_body_table
delete from sales_head_table
delete from services_table
delete from snd_kbd_table
delete from snd_srf_table
delete from storage_logs_table
delete from storage_table
delete from users_table
delete from backup_scheduale_table
delete from products_table
