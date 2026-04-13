import { createClient } from "https://esm.sh/@supabase/supabase-js@2";

const SUPABASE_URL = "https://soqkgdjjupqxjvmpsuxd.supabase.co";
const SUPABASE_KEY = "sb_publishable_EP-CaxQNoNQwsdQuKbMh7w_vInlh_eF";

export const supabase = createClient(SUPABASE_URL, SUPABASE_KEY);
