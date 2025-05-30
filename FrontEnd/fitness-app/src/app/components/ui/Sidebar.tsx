import Link from 'next/link';
import { usePathname } from 'next/navigation';
import {
  HomeIcon,
  FireIcon,
  ChartBarIcon,
  ScaleIcon,
  CameraIcon,
  FlagIcon,
  CogIcon,
} from '@heroicons/react/24/outline';

export function Sidebar() {
  const pathname = usePathname();

  const navItems = [
    { name: 'Dashboard', href: '/dashboard', icon: HomeIcon },
    { name: 'Workouts', href: '/dashboard/workouts', icon: FireIcon },
    { name: 'Exercises', href: '/dashboard/exercises', icon: ChartBarIcon },
    { name: 'Nutrition', href: '/dashboard/nutrition', icon: ScaleIcon },
    { name: 'Measurements', href: '/dashboard/measurements', icon: ChartBarIcon },
    { name: 'Progress', href: '/dashboard/progress', icon: CameraIcon },
    { name: 'Goals', href: '/dashboard/goals', icon: FlagIcon },
    { name: 'Settings', href: '/dashboard/settings', icon: CogIcon },
  ];

  return (
    <div className="hidden md:flex md:flex-shrink-0">
      <div className="flex flex-col w-64 border-r border-gray-200 bg-white">
        <div className="h-0 flex-1 flex flex-col pt-5 pb-4 overflow-y-auto">
          <div className="flex items-center flex-shrink-0 px-4">
            <h1 className="text-xl font-bold text-indigo-600">Fitness Tracker</h1>
          </div>
          <nav className="mt-5 flex-1 px-2 space-y-1">
            {navItems.map((item) => (
              <Link
                key={item.name}
                href={item.href}
                className={`group flex items-center px-2 py-2 text-sm font-medium rounded-md ${
                  pathname === item.href
                    ? 'bg-indigo-100 text-indigo-700'
                    : 'text-gray-600 hover:bg-gray-50 hover:text-gray-900'
                }`}
              >
                <item.icon
                  className={`mr-3 h-5 w-5 ${
                    pathname === item.href
                      ? 'text-indigo-500'
                      : 'text-gray-400 group-hover:text-gray-500'
                  }`}
                />
                {item.name}
              </Link>
            ))}
          </nav>
        </div>
      </div>
    </div>
  );
}