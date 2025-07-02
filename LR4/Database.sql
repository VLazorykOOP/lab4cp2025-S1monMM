CREATE DATABASE IF NOT EXISTS computer_store;

USE computer_store;

CREATE TABLE Computers (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100),
    CPUType VARCHAR(100),
    FrequencyGHz DECIMAL(4,2),
    GPU VARCHAR(100),
    CDType ENUM('CDROM', 'CDRW'),
    SoundCard VARCHAR(100),
    HDD_GB INT
);

USE computer_store;

INSERT INTO Computers (Name, CPUType, FrequencyGHz, GPU, CDType, SoundCard, HDD_GB) VALUES
('Acer Aspire 5',         'Intel Core i5-1135G7', 2.4, 'Intel Iris Xe',         'CDRW', 'Realtek HD',     512),
('Lenovo ThinkPad E15',   'Intel Core i7-1165G7', 2.8, 'Intel Iris Xe',         'CDROM', 'Dolby Digital',  1024),
('HP Pavilion',           'AMD Ryzen 5 5500U',    2.1, 'AMD Radeon',            'CDRW', 'Bang & Olufsen', 256),
('Dell Inspiron 15',      'Intel Core i3-1115G4', 3.0, 'Intel UHD Graphics',    'CDROM', 'Realtek',        128),
('Asus TUF Gaming F15',   'Intel Core i5-11400H', 2.7, 'NVIDIA GeForce RTX 3050','CDRW','SonicMaster',     512),
('MSI GF63 Thin',         'Intel Core i7-10750H', 2.6, 'NVIDIA GTX 1650',       'CDROM', 'Nahimic 3',       512),
('Apple MacBook Air M1',  'Apple M1',             3.2, 'Apple GPU',             'CDROM', 'Apple Audio',     256),
('Acer Nitro 5',          'AMD Ryzen 7 5800H',    3.2, 'NVIDIA RTX 3060',       'CDRW', 'DTS:X Ultra',      1024),
('Lenovo Legion 5',       'AMD Ryzen 5 5600H',    3.3, 'NVIDIA GTX 1660Ti',     'CDRW', 'Nahimic 3',        512),
('HP EliteBook',          'Intel Core i7-10510U', 1.8, 'Intel UHD',             'CDROM', 'Realtek',         256),
('Dell XPS 13',           'Intel Core i5-1230U',  2.5, 'Intel Iris Xe',         'CDROM', 'Waves MaxxAudio', 512),
('Asus VivoBook',         'Intel Core i3-1005G1', 1.2, 'Intel UHD',             'CDRW', 'SonicMaster',      256),
('MSI Prestige 14',       'Intel Core i7-1185G7', 3.0, 'Intel Iris Xe',         'CDROM', 'Nahimic 3',       512),
('Acer Swift 3',          'AMD Ryzen 7 5700U',    2.8, 'AMD Radeon',            'CDROM', 'Realtek HD',      512),
('Lenovo IdeaPad 3',      'Intel Pentium N5030',  1.1, 'Intel UHD 605',         'CDROM', 'Realtek',         128),
('HP Omen 15',            'AMD Ryzen 9 5900HX',   3.3, 'NVIDIA RTX 3070',       'CDRW', 'Bang & Olufsen',  1024),
('Dell Latitude 5510',    'Intel Core i5-10210U', 1.6, 'Intel UHD',             'CDROM', 'Waves Audio',     256),
('Asus ROG Strix G15',    'AMD Ryzen 7 4800H',    2.9, 'NVIDIA RTX 2060',       'CDRW', 'SonicMaster',      512),
('Acer Chromebook 314',   'Intel Celeron N4020',  1.1, 'Intel UHD 600',         'CDROM', 'Basic Audio',     64),
('Lenovo Flex 5',         'AMD Ryzen 5 4500U',    2.3, 'AMD Radeon',            'CDRW', 'Dolby Audio',      512),
('HP ProBook 440 G8',     'Intel Core i5-1135G7', 2.4, 'Intel Iris Xe',         'CDROM', 'Realtek',         256);
