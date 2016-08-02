

/****** Object:  Table [dbo].[release_plans]    Script Date: 2016/7/27 14:42:02 ******/
CREATE TABLE [dbo].[release_plans](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[planned_release_at] [datetime] NULL,
	[dev_owner] [varchar](50) NULL,
	[ops_owner] [varchar](50) NULL,
	[test_owner] [varchar](100) NULL,
	[product_owner] [varchar](50) NULL,
	[notification_list] [varchar](200) NULL,
	[notification_cc_list] [varchar](200) NULL,
	[release_notes] [varchar](200) NULL,
	[git_repo_tag] [varchar](20) NULL,
	[git_repo_ref_tag] [varchar](20) NULL,
	[git_repo_commit_id] [varchar](50) NULL,
	[jenkins_build_no] [int] NULL,
	[replease_package_name] [varchar](20) NULL,
	[release_env] [varchar](20) NULL,
	[service] [varchar](20) NULL,
	[service_git_path] [varchar](50) NULL,
	[status] [int] NULL,
	[create_by] [varchar](50) NULL,
	[create_at] [datetime] NULL,
	[update_by] [varchar](50) NULL,
	[update_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[release_plans] ADD  DEFAULT ((0)) FOR [id]
GO


/****** Object:  Table [dbo].[release_jobs]    Script Date: 2016/7/27 14:38:42 ******/
CREATE TABLE [dbo].[release_jobs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[release_plan_id] [int] NOT NULL,
	[deployment_status] [int] NOT NULL,
	[start_at] [datetime] NULL,
	[finished_at] [datetime] NULL,
	[deployment_log_path] [varchar](200) NULL,
	[deployment_service_path] [varchar](200) NULL,
	[deployment_package_archive_path] [varchar](200) NULL,
	[create_by] [varchar](50) NULL,
	[create_at] [datetime] NULL,
	[update_by] [varchar](50) NULL,
	[update_at] [datetime] NULL,
 CONSTRAINT [PK__release___3213E83FF5A1ACFB] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[release_jobs] ADD  CONSTRAINT [DF_release_jobs_release_plan_id]  DEFAULT ((0)) FOR [release_plan_id]
GO

ALTER TABLE [dbo].[release_jobs] ADD  CONSTRAINT [DF_release_jobs_deployment_status]  DEFAULT ((0)) FOR [deployment_status]
GO

ALTER TABLE [dbo].[release_jobs] ADD  CONSTRAINT [DF_release_jobs_create_at]  DEFAULT (getdate()) FOR [create_at]
GO

ALTER TABLE [dbo].[release_jobs] ADD  CONSTRAINT [DF_release_jobs_update_at]  DEFAULT (getdate()) FOR [update_at]
GO


/****** Object:  Table [dbo].[operation_accidents]    Script Date: 2016/7/27 14:39:18 ******/
CREATE TABLE [dbo].[operation_accidents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](100) NOT NULL,
	[critic_level] [int] NULL,
	[description] [varchar](200) NOT NULL,
	[root_cause] [varchar](500) NULL,
	[resolution] [varchar](max) NULL,
	[impaction] [varchar](max) NULL,
	[impacted_services] [varchar](200) NULL,
	[report_at] [datetime] NULL,
	[level_1_response_at] [datetime] NULL,
	[level_2_response_at] [datetime] NULL,
	[root_cause_identify_at] [datetime] NULL,
	[root_cause_identify_by] [varchar](50) NULL,
	[estimated_fixed_time] [datetime] NULL,
	[actual_fixed_time] [datetime] NULL,
	[fixed_at] [datetime] NULL,
	[fixed_by] [varchar](50) NULL,
	[kb_path] [varchar](200) NULL,
	[created_at] [datetime] NULL,
	[created_by] [varchar](50) NULL,
	[updated_at] [datetime] NOT NULL,
	[updated_by] [varchar](50) NULL,
 CONSTRAINT [PK__operatio__3213E83FA5385D29] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[operation_accidents] ADD  CONSTRAINT [DF_operation_accidents_critic_level]  DEFAULT ((0)) FOR [critic_level]
GO

ALTER TABLE [dbo].[operation_accidents] ADD  CONSTRAINT [DF_operation_accidents_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
