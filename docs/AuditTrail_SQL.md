MySQL table structure for audit trail:

CREATE TABLE `audit_trail` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `username` varchar(100) DEFAULT NULL,
  `form_name` varchar(200) DEFAULT NULL,
  `action` varchar(100) DEFAULT NULL,
  `details` text,
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `idx_audit_username` (`username`),
  KEY `idx_audit_form` (`form_name`),
  KEY `idx_audit_created` (`created_at`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

Notes:
- Use AuditTrail.Log(username, formName, action, details) from your forms to record events.
- The helper swallows exceptions to avoid breaking the app when DB is unavailable. Consider reporting failed audit inserts separately if required.
